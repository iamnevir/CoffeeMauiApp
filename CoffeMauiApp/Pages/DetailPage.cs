using MauiReactor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMauiApp.Pages;

class DetailPageState
{
    public double TranslateX { get;set; }
    public Size Size { get;set; }
}
class DetailPage: Component<DetailPageState>
{
    Coffee _coffee;
    Action _backAction;

    public DetailPage GetCoffee(Coffee coffee)
    {
        _coffee = coffee;
        return this;
    }
    public DetailPage OnCancelSelection(Action action)
    {
        _backAction = action;
        return this;
    }

    protected override void OnMounted()
    {
        _ = _coffee != null ? State.TranslateX = 0 : State.TranslateX = 400;
        base.OnMounted();
    }

    protected override void OnPropsChanged()
    {
;       _ = _coffee != null ? State.TranslateX = 0 : State.TranslateX = 400;
        base.OnPropsChanged();
    }
    public override VisualNode Render()
    {
        return new Grid("490,*","*")
        {
            new Border
            {
                new Grid
                {
                     new Image("coffe1").Aspect(Aspect.Fill)
                     .Margin(0,0,0,0),
                     new Border
                     {
                         new AcrylicView
                         {
                             new HStack
                            {
                                new VStack
                                {
                                    new Label("Cappuccino")
                                    .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                    .TextColor(Colors.White)
                                    .FontSize(25),
                                    new Label("With Oat Milk")
                                    .TextColor(Colors.Gray)
                                    .FontSize(18),
                                    new HStack
                                    {
                                        new Image("star").HeightRequest(17),
                                        new Label("4.5")
                                        .TextColor(Colors.White)
                                        .FontSize(19),
                                        new Label("(6.986)")
                                        .TextColor(Colors.Gray)
                                        .FontSize(15).VCenter().Margin(0,2,0,0),
                                    }.Spacing(5)
                                }.Spacing(10).Margin(35,20,0,0),
                                new VStack
                                {
                                    new HStack
                                    {
                                        new Border
                                        {
                                            new VStack
                                            {
                                                new Image("hat").HeightRequest(25)
                                                .VCenter()
                                                .HCenter(),
                                                new Label("Coffee")
                                                .TextColor(Colors.Gray)
                                                .FontSize(12)
                                                .HCenter()
                                            }.VCenter()
                                        }.BackgroundColor(Theme.Bg)
                                        .HeightRequest(55)
                                        .WidthRequest(50)
                                        .StrokeShape(new RoundRectangle().CornerRadius(10))
                                        ,
                                        new Border
                                        {
                                            new VStack
                                            {
                                                new Image("milk").HeightRequest(23)
                                                .HCenter(),
                                                new Label("Milk")
                                                .TextColor(Colors.Gray)
                                                .FontSize(12)
                                                .HCenter()
                                            }.VCenter()
                                        }.BackgroundColor(Theme.Bg)
                                        .HeightRequest(55)
                                        .WidthRequest(50)
                                        .StrokeShape(new RoundRectangle().CornerRadius(10))
                                    }.Spacing(20),
                                    new Border
                                        {
                                            new Label("Medium Roasted")
                                            .FontSize(13)
                                            .TextColor(Colors.Gray)
                                            .HCenter()
                                            .VCenter()
                                        }.BackgroundColor(Theme.Bg)
                                        .HeightRequest(40)
                                        .WidthRequest(120)
                                        .StrokeShape(new RoundRectangle().CornerRadius(10))
                                }.HEnd().VCenter().Spacing(15)
                             }.Spacing(50).Margin(0,10,0,0)
                         }.EffectStyle(Xe.AcrylicView.Controls.EffectStyle.ExtraDark)
                     }.BackgroundColor(Colors.Transparent)
                     .HeightRequest(160)
                     .WidthRequest(370)
                     .StrokeShape(new RoundRectangle().CornerRadius(45,45,0,0))
                     .Margin(0,0,0,-2)
                     .VEnd(),

                }
               
            }.GridRow(0).WidthRequest(370)
            .Stroke(Colors.Transparent)
            .StrokeShape(new RoundRectangle().CornerRadius(30))
            .Margin(0,10,0,0)
            ,
            new Border
            {
                new Image("back").HeightRequest(40)
            }
            .StrokeShape(new RoundRectangle().CornerRadius(10))
            .HeightRequest(35)
            .WidthRequest(35)
            .BackgroundColor(Theme.BorderColor)
            .VStart()
            .Margin(30,40,0,0)
            .HStart()
            .OnTapped(_backAction),
             new Border
            {
                new Image("heart").HeightRequest(40).Aspect(Aspect.AspectFit)
            }
            .StrokeShape(new RoundRectangle().CornerRadius(10))
            .HeightRequest(35)
            .WidthRequest(35)
            .BackgroundColor(Theme.BorderColor)
            .VStart()
            .Margin(0,40,30,0)
            .HEnd(),
             new Grid("Auto,75,Auto,30,*","*")
             {
                 new Label("Description")
                 .FontSize(16)
                 .TextColor(Colors.Gray)
                 .GridRow(0),
                 new Label("A cappuccino is a coffee-based drink made primarily espresso and milk")
                 .FontSize(16)
                 .TextColor(Colors.White)
                 .LineHeight(1.2)
                 .GridRow(1)
                 .Margin(0,10,0,0),
                 new Label("...Read More")
                  .FontSize(16)
                 .TextColor(Theme.Cam)
                 .GridRow(1)
                 .HEnd()
                 .VEnd()
                 .Margin(0,0,65,20),
                 new Label("Size") 
                 .FontSize(17)
                 .TextColor(Colors.Gray)
                 .GridRow(2),
                 new HStack
                 {
                     new Border
                     {
                         new Label("S").FontSize(16)
                         .HCenter()
                         .VCenter()
                         .TextColor (State.Size==Size.S?Theme.Cam:Colors.Gray),
                     }.Stroke(State.Size==Size.S?Theme.Cam:Colors.Transparent)
                     .WidthRequest(100)
                     .HeightRequest(40)
                     .StrokeThickness(2)
                     .StrokeShape(new RoundRectangle().CornerRadius(10))
                     .BackgroundColor(State.Size==Size.S?Colors.Black:Theme.BorderColor)
                     .OnTapped(()=>SetState(s=>s.Size=Size.S)),
                       new Border
                     {
                         new Label("M").FontSize(16)
                         .HCenter()
                         .VCenter()
                         .TextColor (State.Size==Size.M?Theme.Cam:Colors.Gray),
                     }.Stroke(State.Size==Size.M?Theme.Cam:Colors.Transparent)
                     .WidthRequest(100)
                     .HeightRequest(40)
                     .StrokeThickness(2)
                     .StrokeShape(new RoundRectangle().CornerRadius(10))
                     .BackgroundColor(State.Size==Size.M?Colors.Black:Theme.BorderColor)
                     .OnTapped(()=>SetState(s=>s.Size=Size.M)),
                         new Border
                     {
                         new Label("L").FontSize(16)
                         .HCenter()
                         .VCenter()
                         .TextColor (State.Size==Size.L?Theme.Cam:Colors.Gray),
                     }.Stroke(State.Size==Size.L?Theme.Cam:Colors.Transparent)
                     .WidthRequest(100)
                     .HeightRequest(40)
                     .StrokeThickness(2)
                     .StrokeShape(new RoundRectangle().CornerRadius(10))
                     .BackgroundColor(State.Size==Size.L?Colors.Black:Theme.BorderColor)
                     .OnTapped(()=>SetState(s=>s.Size=Size.L)),
                 }.Spacing(15).GridRow(3).Margin(0,25,0,0)
                 ,
                   new Border
                 {
                         new HStack
                         {
                             new VStack
                             {
                                 new Label("Price")
                                 .FontSize(16)
                                 .HCenter()
                                 .TextColor(Colors.Gray),
                                 new HStack
                                 {
                                     new Label("$")
                                     .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                     .FontSize(20)
                                     .TextColor(Theme.Cam),
                                     new Label("4.20")
                                     .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                     .FontSize(20)
                                     .TextColor(Colors.White),
                                 }.Spacing(5)
                             }.Spacing(0).VCenter().Margin(0,0,0,0),
                             new Border
                             {
                                 new Label("Buy Now").TextColor(Colors.White)
                                 .HCenter()
                                 .VCenter()
                                 .FontSize(18)
                                 .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                             }.WidthRequest(220)
                             .HeightRequest(60)
                             .StrokeShape(new RoundRectangle().CornerRadius(20))
                             .BackgroundColor(Theme.Cam)
                             .Margin(30,0,0,0),
                         }.Spacing(20)
                         .HCenter()
                 }.BackgroundColor(Colors.Transparent)
                 .VEnd()
                 .Margin(-30,0,0,-5)
                 .HeightRequest(120)
                 .WidthRequest(370)
                 .GridRow(4),
             }.GridRow(2).Margin(25,20,0,0)
        }.BackgroundColor(Theme.Bg)
        .TranslationX(State.TranslateX)
        .WithAnimation(easing:Easing.CubicInOut,duration:1300);
    }
}
public enum Size
{
    S,
    M,
    L
}