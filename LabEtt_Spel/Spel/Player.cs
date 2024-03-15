namespace Spel;

public class Player : Characters
{
    public int XPositions { get; set; }
    public int YPosition { get; set; }
    public Player(string name,double vitality, int postionX, int postionY) : base(name,1.1,vitality, 2.0, 3.0, 4.0,5.0,6.0,7.0,8.0,9.0) 
    { 
        name="😒"; //this the shape i want. 
        this.Name= name; 
        vitality =10;
        this.Vitality = vitality;
        this.XPositions = postionX;
        this.YPosition = postionY;
        Console.Write(name);
    }
    public override void ShowingTheCreatures()
    {
        Console.WriteLine(this.Name + this.Vitality);
    }
    public void MoveLeft(){
        if(XPositions < Console.WindowWidth -1){
            XPositions --;
            UpdateLocation();
        }
    }
     public void MoveRight(){
        if(XPositions < Console.WindowWidth -1){
            XPositions ++;
            UpdateLocation();
        }
    }
    public void MoveUp(){
        if(YPosition < Console.WindowHeight - 1){
            YPosition --;
            UpdateLocation();
        }
    }
    public void MoveDown(){
        if(YPosition < Console.WindowHeight -1){
            YPosition ++;
            UpdateLocation();
        }
    }
            private void UpdateLocation()
        {
            Console.Clear();
            Console.SetCursorPosition(XPositions, YPosition);
            Console.Write(Name);
        }
}