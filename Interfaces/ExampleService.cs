using OMS.Entities;


namespace OMS.Interfaces
{
    public class ExampleService
    {

       public Example [] allExamples = new[] {
        new Example()
        {
            Name = "Home",
            Path = "/",
            Icon = "&#xe88a"
        },
        new Example()
        {
            Name = "Customer",
            Path = "/customerlist",
            Title = "Rich dasboard created with the Radzen Blazor components",
            Icon = "&#xe871"
        },
        new Example
        {
            Name = "Product",
            Title = "How to get started with the Radzen Blazor components",
            Path = "/productlist",
            Icon = "&#xe037"
        },
        new Example
        {
            Name = "Order",
            Title = "How to get support for the Radzen Blazor components",
            Path = "/orderlist",
            Icon = "&#xe94c"
        }
            };
    }


}
