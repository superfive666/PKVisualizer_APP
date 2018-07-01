namespace interactivegraph.Base_Entities
{
    public class GraphSettings
    {
        #region Public constructor
        /// <summary>
        /// Publically instantiate the horizonal max and vertical max
        /// </summary>
        /// <param name="h"></param>
        /// <param name="v"></param>
        public GraphSettings(double h, double v)
        {
            HorizontalMax = h;
            VerticalMax = v;
        }
        #endregion

        public double HorizontalMax { get; private set; }
        public double VerticalMax { get; private set; }

        public double[] HorizontalTicks { get; set; }
        public double[] VerticalTicks { get; set; }
    }
}