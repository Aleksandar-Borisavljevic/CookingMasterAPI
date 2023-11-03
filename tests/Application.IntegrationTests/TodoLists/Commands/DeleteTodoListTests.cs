using CookingMasterApi.Application.Common.Exceptions;
using CookingMasterApi.Application.TodoLists.Commands.CreateTodoList;
using CookingMasterApi.Application.TodoLists.Commands.DeleteTodoList;
using CookingMasterApi.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CookingMasterApi.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
