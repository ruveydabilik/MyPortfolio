namespace MyPortfolio.DAL.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageSource { get; set; }
        public string SecondImageSource { get; set; }
        public string ThirdImageSource { get; set; }
        public string ProjectLink { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
    }
}
