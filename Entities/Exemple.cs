
namespace OMS.Entities
{
    public class Exemple
    {

       public bool collapseNavMenu = true;
       public string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
       public void ToggleNavMenu()
       {
            collapseNavMenu = !collapseNavMenu;
       }


    }
}
