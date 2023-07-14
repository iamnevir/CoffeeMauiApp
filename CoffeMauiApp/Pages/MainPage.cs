using MauiReactor.Shapes;
using System;
using System.Collections.Generic;

namespace CoffeMauiApp.Pages;


[Scaffold(typeof(Xe.AcrylicView.AcrylicView))]
public partial class AcrylicView { }
class MainPageState
{
    public List<Category> Categories { get; set; } = CoffeeService.GetCategories();
    public List<Coffee> Coffees { get; set; } = CoffeeService.GetCoffees();
    public int SelectedCategoryId { get; set; } = 1;
    public int? SelectedCoffeeId { get; set; }

}

class MainPage : Component<MainPageState>
{
    public override VisualNode Render()
    {
        return new ContentPage
        {   new Grid("*","*")
            {
                 new ScrollView
                {
                     new Grid("75,100,100,100,280,75,*","*")
                    {
                        new Border
                        {
                            new HStack
                            {
                                new Image("imgmenu")
                                .HeightRequest(25)
                                .WidthRequest(25)
                                .HStart()
                                .VCenter(),
                                new Border
                                {
                                    new Image("phoenix")
                                    .Aspect(Aspect.AspectFit)
                                }.Stroke(Theme.BorderColor)
                                .StrokeThickness(4)
                                .StrokeShape(new RoundRectangle().CornerRadius(11))
                                .HEnd()
                                .HeightRequest(55)
                                .WidthRequest(55)
                                .VCenter()
                            }.Spacing(280)
                        }.GridRow(0).BackgroundColor(Colors.Transparent).Margin(15,0,0,0)
                        ,
                        new Label("Find the best coffee for you")
                        .TextColor(Colors.White)
                        .FontAttributes(MauiControls.FontAttributes.Bold)
                        .FontFamily("OpenSansSemiBold")
                        .FontSize(35)
                        .GridRow(1)
                        .WidthRequest(300)
                        .HStart()
                        .Margin(15,0,0,0),
                        new Border
                        {
                            new HStack
                            {
                                new Ellipse()
                                .Fill(Theme.Search)
                                .HeightRequest(20)
                                .WidthRequest(20)
                                .Margin(25,4,0,10),
                                new Label("-")
                                .FontSize(30)
                                .TextColor(Theme.Search)
                                .Rotation(40)
                                .Margin(-15,9,0,0),
                                new Label("Find Your Coffee ...")
                                .FontSize(14)
                                .VCenter()
                                .TextColor (Theme.Search)
                                .Margin(10,0,0,0),
                            }.Spacing(10)
                        }.BackgroundColor(Theme.BorderBg)
                        .GridRow (2).HCenter()
                        .StrokeShape(new RoundRectangle().CornerRadius(10))
                        .HeightRequest(55)
                        .WidthRequest(360),
                        new CollectionView().ItemsSource(State.Categories,RenderCategory)
                        .SelectionMode(MauiControls.SelectionMode.Single)
                        .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(25))
                        .Margin(15,20,0,0)
                        .GridRow(3)
                        ,
                        new CollectionView().ItemsSource(State.Coffees,RenderCoffee)
                        .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(20))
                        .Margin(15,0,0,0)
                        .GridRow(4)
                        .VStart()
                        .BackgroundColor(Colors.Transparent)
                        ,
                        new Label("Special for you")
                        .TextColor(Colors.White)
                        .GridRow(5)
                        .FontSize(20)
                        .Margin(15,15,0,0),
                        new CollectionView().ItemsSource(State.Coffees,RenderCoffee1)
                        .ItemsLayout(new VerticalLinearItemsLayout().ItemSpacing(20))
                        .Margin(15,0,0,50)
                        .GridRow(6)
                        .VStart()
                        .BackgroundColor(Colors.Transparent)
                    }.WidthRequest(380)
                    .HCenter()
                },
                 new Border
                 {
                         new HStack
                         {
                             new Image("home").HeightRequest(30).WidthRequest(30).Aspect(Aspect.AspectFill),
                             new Image("bag").HeightRequest(30).WidthRequest(30).Aspect(Aspect.AspectFill),
                             new Image("heart").HeightRequest(30).WidthRequest(30).Aspect(Aspect.AspectFill),
                             new Image("ring").HeightRequest(30).WidthRequest(30).Aspect(Aspect.AspectFill),
                         }.Spacing(60)
                         .HCenter()
                 }.BackgroundColor(Theme.Bg)
                 .VEnd()
                 .Margin(0,0,0,-5)
                 .HeightRequest(75).WidthRequest(390),
                 new DetailPage()
                 .GetCoffee(State.SelectedCoffeeId != null ? CoffeeService.GetCoffeesById(State.SelectedCoffeeId) : null)
                 .OnCancelSelection(()=>SetState(s=>s.SelectedCoffeeId=null))
            }
           
        }.BackgroundColor(Theme.Bg);
    }

    private VisualNode RenderCoffee1(Coffee coffee)
    {
        return new Border
        {
            new HStack
            {
                new Border
                {
                      new Image(coffee.Image)
                        .Aspect(Aspect.AspectFill)
                        
                }.Stroke(Colors.Transparent)
                .BackgroundColor(Colors.Transparent)
                .StrokeShape(new RoundRectangle().CornerRadius(25))
                .HeightRequest(140)
                 .WidthRequest(135)
                 .Margin(15,0,0,0)
                ,
                new Label("5 Coffee Beans You Must Try !")
                .TextColor(Colors.White)
                .FontSize(20)
                .WidthRequest(180)
                .Margin(0,15,0,0)
            }.Spacing(10)
        }.HeightRequest(170)
        .StrokeShape(new RoundRectangle().CornerRadius(25))
        .Background(Theme.BorderBg)
        .OnTapped(() => SetState(s => s.SelectedCoffeeId = coffee.Id));
    }

    private VisualNode RenderCoffee(Coffee coffee)
    {
        return new Border
        {
               new Grid
               {
                   new Border
                   {
                       new Grid
                       {
                               new Border
                               {
                                   new AcrylicView
                                   {
                                           new HStack
                                           {
                                               new Image("star")
                                               .HeightRequest(9)
                                               .WidthRequest(9),
                                               new Label(coffee.Rate)
                                               .TextColor(Colors.White)
                                               .FontSize(10)
                                           }.Spacing(5).Margin(6,4,0,4),
                                   }.EffectStyle(Xe.AcrylicView.Controls.EffectStyle.Dark).TintColor(Colors.Transparent),
                               }.StrokeShape(new RoundRectangle().CornerRadius(0,0,50,0))
                               .BackgroundColor(Colors.Transparent)
                               .HEnd()
                               .Margin(0,-2,0,0)
                               .Stroke(Colors.Transparent)
                               .VStart().HeightRequest(23)
                               .WidthRequest(50).ZIndex(1),

                            new Image(coffee.Image).Aspect(Aspect.AspectFill)

                       }
                   }.HeightRequest(140).WidthRequest(135)
                   .VStart()
                   .Margin(0,10,0,0)
                   .Stroke(Colors.Transparent)
                   .StrokeShape(new RoundRectangle().CornerRadius(20))
                   ,
                   new VStack
                   {
                        new Label(coffee.Name)
                       .TextColor(Colors.White)
                       .FontSize(18),
                       new Label(coffee.With)
                       .FontSize(12)
                       .TextColor(Colors.Gray),
                   }.VCenter().Margin(10,110,0,0).Spacing(3),
                   new HStack
                   {
                       new Label("$")
                       .TextColor(Theme.Cam)
                       .FontAttributes(MauiControls.FontAttributes.Bold)
                       .FontSize(20)
                       .Margin(0,8,0,0),
                       new Label(coffee.Price)
                       .TextColor(Colors.White)
                       .FontSize(20)
                       .Margin(0,8,0,0)
                       ,
                       new Border
                       {
                           new Label("+")
                           .TextColor(Colors.White)
                           .FontSize(20)
                           .Margin(0,0,0,2)
                           .HCenter()
                           .VCenter()
                       }.HeightRequest(35)
                       .WidthRequest(35)
                       .BackgroundColor(Theme.Cam)
                       .Margin(40,0,0,15)
                       .StrokeShape(new RoundRectangle().CornerRadius(10))
                   }.VEnd().Spacing(5).Margin(10,0,0,0),
                  
               }.BackgroundColor(Colors.Transparent)
        }.Background(Theme.BorderBg)
        .StrokeShape(new RoundRectangle().CornerRadius(20))
        .HeightRequest(257)
        .WidthRequest(165)
        .OnTapped(()=>SetState(s=>s.SelectedCoffeeId=coffee.Id));
    }

    private VisualNode RenderCategory(Category category)
    {
        return new VStack
        {
               new Label(category.Name)
                    .TextColor(State.SelectedCategoryId==category.Id ?Theme.Cam :Theme.Search)
                    .FontSize(20)
                    .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold),
               new Ellipse().Fill(State.SelectedCategoryId==category.Id ?Theme.Cam :Colors.Transparent)
                        .HeightRequest(10)
                        .WidthRequest(10)
                        .Margin(0,10,0,0)
                        .HCenter(),
        }.OnTapped(()=> SetState(s => s.SelectedCategoryId = category.Id))
      ;
    }
}