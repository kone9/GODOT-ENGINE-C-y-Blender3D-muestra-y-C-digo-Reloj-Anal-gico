using Godot;
using System;

public class relog : MeshInstance
{
    [Export]
    public float segundos;
    [Export]
    public float minutos;
    [Export]
    public float hora;
    
    
    public override void _Ready()
    {
       
    }

    public override void _Process(float delta)
    {
        DateTime HoraActual = DateTime.Now; //busca el tiempo del sistema
        segundos = (float)HoraActual.Second;//tomo los segundos del sistema
        minutos = (float)HoraActual.Minute;//tomo los minuts del sistema
        hora = (float)HoraActual.Hour;//tomo las horas del sistema
        GD.Print(hora+" : "+ minutos +" : "+ segundos);//muestra la hora por consola
        
        //GetNode<MeshInstance>("segundos").RotateY(-5.0f * delta);
        //GetNode<MeshInstance>("minutos").RotateY(-2.0f * delta);
        //GetNode<MeshInstance>("hora").RotateY(-0.5f * delta);
        
        actualizarAgujas();
    }
        



    private void actualizarAgujas()
    {   

        float segundosangulo = -1*((segundos * 6) - 360);//calcula segundos
        float minutoangulo = -1*((minutos * 6) + (segundos / 10) - 360);//calcula minutos
        float horaangulo = -1*((hora * 30) + (minutos / 2) + (segundos / 120) - 360);//calcula hora

    
        GetNode<MeshInstance>("segundos").SetRotationDegrees(new Vector3(90,segundosangulo,0));//rota segundos
        GetNode<MeshInstance>("minutos").SetRotationDegrees(new Vector3(90,minutoangulo,0));//rota minutos
        GetNode<MeshInstance>("hora").SetRotationDegrees(new Vector3(90,horaangulo,0));//rota hora
               
       
    }

}
