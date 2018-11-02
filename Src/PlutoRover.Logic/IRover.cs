namespace PlutoRover.Logic
{
    public interface IRover
    {
        Action[] Route { get; set; }

        string Back();
        string Forward();
        string Left();
        string Right();
        void CalculateRoute(string commands);
        void ExecuteRoute();
        string FinalPosition();
    }
}