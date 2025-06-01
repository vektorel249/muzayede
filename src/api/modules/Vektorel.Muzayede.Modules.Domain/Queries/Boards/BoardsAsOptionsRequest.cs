using MediatR;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Common;
using Vektorel.Muzayede.Common.Dtos;
using Vektorel.Muzayede.Data;

namespace Vektorel.Muzayede.Modules.Domain.Queries.Boards;

public class BoardsAsOptionsRequest : IRequest<Result<List<OptionItem>>>
{
}

internal class BoardsAsOptionsQuery : IRequestHandler<BoardsAsOptionsRequest, Result<List<OptionItem>>>
{
    private readonly MuzayedeContext context;

    public BoardsAsOptionsQuery(MuzayedeContext context)
    {
        this.context = context;
    }
    public async Task<Result<List<OptionItem>>> Handle(BoardsAsOptionsRequest request, CancellationToken cancellationToken)
    {
        var boards = await context.Boards.Where(f => f.IsActive)
                                         .Select(s => new OptionItem
                                         {
                                             Value = s.Id,
                                             Title = s.Title,
                                         })
                                         .ToListAsync(cancellationToken);

        return Result<List<OptionItem>>.Success(boards);
    }
}
