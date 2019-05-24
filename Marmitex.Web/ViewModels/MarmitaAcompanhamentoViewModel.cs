namespace Marmitex.Web.ViewModels
{
    public class MarmitaAcompanhamentoViewModel
    {
        public long Id { get; set; }
        public MarmitaViewModel Marmita { get; set; }
        public long MarmitaId { get; set; }
        public AcompanhamentoViewModel Acompanhamento { get; set; }
        public long AcompanhamentoId { get; set; }
    }
}