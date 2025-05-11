namespace Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Proposals;

public class ProposalDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
public record GetProposalsResult(List<ProposalDto> Proposals);
