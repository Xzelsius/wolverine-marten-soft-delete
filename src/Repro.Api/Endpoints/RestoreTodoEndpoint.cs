using Marten;
using Marten.Linq.SoftDeletes;
using Microsoft.AspNetCore.Mvc;
using Repro.Api.Domain;
using Repro.Api.Domain.Events;
using System.ComponentModel.DataAnnotations;
using Wolverine.Http;

namespace Repro.Api.Endpoints;

public static class RestoreTodoEndpoint
{
    public static Task<Todo?> Load(Guid todoId, IDocumentSession session)
    {
        return session.Query<Todo>().SingleOrDefaultAsync(x => x.Id == todoId && x.MaybeDeleted());
    }

    [WolverinePost("/todos/{todoId}/restore"), EmptyResponse]
    public static void Restore([FromRoute] Guid todoId, [NotBody][Required] Todo todo, IDocumentSession session)
    {
        session.UndoDeleteWhere<Todo>(x => x.Id == todoId);
        session.Events.Append(todo.Id, new TodoRestored(todo.Id));
    }
}
