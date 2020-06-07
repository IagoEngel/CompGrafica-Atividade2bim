using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Projeto3D
{
    class Program
    {
        static float fAspect;
        static double yLook = 0, xLook = 0, zLook = 4;
        static float tx = 0.0f, ty = -1.0f, tz=0.0f;

        static void Bola()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.803922f, 0.521569f, 0.247059f);
            Gl.glTranslatef(tx, ty, tz);
            Glut.glutSolidSphere(1.0f, 200, 200);
            Gl.glPopMatrix();
        }
        static void DesenhaQuadra()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(1.0f, 0.5f, 0.0f);
            Gl.glScalef(15.0f, 0.5f, 28.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
        }
        static void HasteCesta1()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.23f, 0.23f, 0.23f);
            Gl.glScalef(0.5f, 3.0f, 0.5f);
            Gl.glTranslatef(0.0f, -0.5f, 28.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
        }
        static void Tabela1()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.117f, 0.388f, 0.835f);
            Gl.glScalef(1.8f, 1.05f, 0.5f);
            Gl.glTranslatef(0.0f, -3.0f, -27.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
        }
        static void Cesta1()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.2f,0.2f,0.2f);
            Gl.glScalef(1.0f, 1.0f, 0.4f);
            Gl.glTranslatef(0.0f, -3.0f, -32.6f);
            Gl.glRotatef(90.0f, 10.0f, 0.0f, 0.0f);
            Glut.glutSolidTorus(0.10f,0.5f,200,200);
            Gl.glPopMatrix();
        }
        static void HasteCesta2()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.23f, 0.23f, 0.23f);
            Gl.glScalef(0.5f, 3.0f, 0.5f);
            Gl.glTranslatef(0.0f, -0.5f, -28.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
        }
        static void Tabela2()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.117f, 0.388f, 0.835f);
            Gl.glScalef(1.8f, 1.05f, 0.5f);
            Gl.glTranslatef(0.0f, -3.0f, 27.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
        }
        static void Cesta2()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.2f, 0.2f, 0.2f);
            Gl.glScalef(1.0f, 1.0f, 0.4f);
            Gl.glTranslatef(0.0f, -3.0f, 32.6f);
            Gl.glRotatef(90.0f, 10.0f, 0.0f, 0.0f);
            Glut.glutSolidTorus(0.10f, 0.5f, 200, 200);
            Gl.glPopMatrix();
        }
        static void Desenha()
        {
            Gl.glPushMatrix();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            DesenhaQuadra();
            HasteCesta1();
            Tabela1();
            Cesta1();
            HasteCesta2();
            Tabela2();
            Cesta2();
            Bola();
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }
        static void Inicializa()
        {
            float[] luzAmbiente = { 0.5f, 0.5f, 0.5f, 0.5f };
            float[] luzDifusa = { 0.7f, 0.7f, 0.7f, 0.7f }; // "cor"
            float[] luzEspecular = { 0.7f, 0.7f, 0.7f, 0.7f };// "brilho"
            float[] posicaoLuz = { float.Parse(xLook.ToString()), float.Parse(yLook.ToString()), float.Parse(zLook.ToString()), 1.0f };
            // Capacidade de brilho do material
            float[] especularidade = { 1.0f, 1.0f, 1.0f, 1.0f };
            int especMaterial = 60;
            // Especifica que a cor de fundo da janela será preta
            Gl.glClearColor(0.8f, 0.8f, 0.8f, 1.0f);
            // Habilita o modelo de colorização de Gouraud
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // Define a refletância do material
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, especularidade);
            // Define a concentração do brilho
            Gl.glMateriali(Gl.GL_FRONT, Gl.GL_SHININESS, especMaterial);
            // Ativa o uso da luz ambiente
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, luzAmbiente);
            // Define os parâmetros da luz de número 0
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, luzAmbiente);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, luzDifusa);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, luzEspecular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, posicaoLuz);
            // Habilita a definição da cor do material a partir da cor corrente
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //Habilita o uso de iluminação
            Gl.glEnable(Gl.GL_LIGHTING);
            // Habilita a luz de número 0
            Gl.glEnable(Gl.GL_LIGHT0);
            // Habilita o depth-buffering
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }
        // Função usada para especificar o volume de visualização
        static void EspecificaParametrosVisualizacao()
        {
            // Especifica sistema de coordenadas de projeção
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // Inicializa sistema de coordenadas de projeção
            Gl.glLoadIdentity();
            // Especifica a projeção perspectiva
            Glu.gluPerspective(200, fAspect, 0.2, 30.0);
            // Especifica sistema de coordenadas do modelo
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        static void SpecialKeys(int key, int x, int y)
        {
            switch (key)
            {
                //camera
                case Glut.GLUT_KEY_F12:
                    yLook += 0.1;
                    break;
                case Glut.GLUT_KEY_INSERT:
                    yLook -= 0.1;
                    Console.WriteLine(yLook.ToString());
                    break;

                case Glut.GLUT_KEY_PAGE_DOWN:
                    xLook -= 0.1;
                    break;
                case Glut.GLUT_KEY_PAGE_UP:
                    xLook += 0.1;
                    break;
                case Glut.GLUT_KEY_HOME:
                    zLook += 0.1;
                    break;
                case Glut.GLUT_KEY_END:
                    zLook -= 0.1;
                    break;

                //bola
                case Glut.GLUT_KEY_LEFT:
                    tx += 1.0f;
                    if (tx > 6.0f)
                    {
                        tx -= 1.0f;
                    }
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    tx -= 1.0f;
                    if (tx < -6.0f)
                    {
                        tx += 1.0f;
                    }
                    break;
                case Glut.GLUT_KEY_F3:
                    Gl.glDisable(Gl.GL_LIGHT0);
                    break;
                case Glut.GLUT_KEY_F4:
                    Gl.glEnable(Gl.GL_LIGHT0);
                    break;
                case Glut.GLUT_KEY_DOWN:
                    tz += 1.0f;
                    if (tz > 13.0f)
                    {
                        tz -= 1.0f;
                    }
                    break;
                case Glut.GLUT_KEY_UP:
                    tz -= 1.0f;
                    if (tz < -13.0f)
                    {
                        tz += 1.0f;
                    }
                    break;

            }
            // Inicializa sistema de coordenadas do modelo
            Gl.glLoadIdentity();
            // Especifica posição do observador e do alvo
            Glu.gluLookAt(xLook, yLook, zLook, 0, 1, 0, 0, 5, 0);
            Glut.glutPostRedisplay();
        }

        // Função callback chamada quando o tamanho da janela é alterado
        static void AlteraTamanhoJanela(int w, int h)
        {
            // Para previnir uma divisão por zero
            if (h == 0) h = 1;
            // Especifica o tamanho da viewport
            Gl.glViewport(0, 0, w, h);
            // Calcula a correção de aspecto
            fAspect = (float)w / (float)h;
            EspecificaParametrosVisualizacao();
        }
        static void Main()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(1980, 1600);
            Glut.glutCreateWindow("Basquete");
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(Desenha);
            Glut.glutReshapeFunc(AlteraTamanhoJanela);
            Glut.glutSpecialFunc(SpecialKeys);
            Inicializa();
            Glut.glutMainLoop();
        }
    }
}