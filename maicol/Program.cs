using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SimpleCar3D
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    // Configuración inicial de OpenGL
                    GL.ClearColor(Color.Black);
                    GL.Enable(EnableCap.DepthTest);
                };

                game.Resize += (sender, e) =>
                {
                    // Ajustar la vista al tamaño de la ventana
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.RenderFrame += (sender, e) =>
                {
                    // Limpia la pantalla y el búfer de profundidad
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    // Configura la matriz de proyección
                    Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.Width / (float)game.Height, 1, 100);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref projection);

                    // Configura la matriz de vista (cámara)
                    Matrix4 view = Matrix4.LookAt(new Vector3(2,1,4), Vector3.Zero, Vector3.UnitY);
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadMatrix(ref view);
                    GL.Begin(PrimitiveType.Quads);

                    ////carrito
                    //cuerpo del auto 
                    GL.Color3(Color.Blue);
                    GL.Vertex3(0.4, 0.2, 1);
                    GL.Vertex3(0.4, 0.5, 1);
                    GL.Vertex3(1.93, 0.5, 1);
                    GL.Vertex3(1.93, 0.2, 1);

                    GL.Color3(Color.Gray);
                    GL.Vertex3(1.4, 0.5, 1);
                    GL.Vertex3(1.4, 0.7, 1);
                    GL.Vertex3(1.5, 0.7, 1);
                    GL.Vertex3(1.5, 0.5, 1);
                    //rueda 1
                    GL.Color3(Color.Black);
                    GL.Vertex3(0.6, 0.2, 1);
                    GL.Vertex3(0.6, 0, 1);
                    GL.Vertex3(0.8, 0, 1);
                    GL.Vertex3(0.8, 0.2, 1);
                    //rueda 2
                    GL.Color3(Color.Black);
                    GL.Vertex3(1.6, 0.2, 1);
                    GL.Vertex3(1.6, 0, 1);
                    GL.Vertex3(1.8, 0, 1);
                    GL.Vertex3(1.8, 0.2, 1);

                    // pared
                    GL.Color3(Color.Brown);
                    GL.Vertex3(2,-2,0);
                    GL.Vertex3(0,-2,0);
                    GL.Vertex3(0,2,0);
                    GL.Vertex3(2,2,0);

                    //repisa 
                    GL.Color3(Color.White);
                  
                    GL.Vertex3(2, 0, 1.6);
                    GL.Vertex3(0, 0, 1.6);
                    GL.Vertex3(0, -0.2, 1.6);
                    GL.Vertex3(2, -0.2, 1.6);
              
                    //
                    GL.Vertex3(2, 0, 0);
                    GL.Vertex3(2, 0, 1.6);
                    GL.Vertex3(0, 0, 1.6);
                    GL.Vertex3(0, 0, 0);

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
