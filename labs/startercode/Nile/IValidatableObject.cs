/*
 * Lesley Reller
 * ITSE 1430
 * 04/14/2020
 */
namespace Nile
{
    public interface IValidatableObject
    {
        string Description { get; set; }
        int Id { get; set; }
        bool IsDiscontinued { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }

        string ToString ();
    }
}