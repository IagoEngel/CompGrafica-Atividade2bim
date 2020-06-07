using Tao.FreeGlut;
using Tao.OpenGl;

namespace ProjetoIluminacaoTeapoat
{
    class Program
    {

        static float angle, fAspect;
        static double yLook, xLook, zLook;
        static float tx = 0.0f;

        static void Desenha()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Glut.glutSolidTeapot(50.0f);
            Glut.glutSwapBuffers();
        }
        // Inicializa parâmetros de rendering para Iluminação
        static void Inicializa()
        {
            float[] luzAmbiente = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] luzDifusa = { 0.7f, 0.7f, 0.7f, 1.0f }; // "cor"
            float[] luzEspecular = { 1.0f, 1.0f, 1.0f, 1.0f };// "brilho"
            float[] posicaoLuz = { 0.0f, 50.0f, 50.0f, 1.0f };
            // Capacidade de brilho do material
            float[] especularidade = { 1.0f, 1.0f, 1.0f, 1.0f };
            int especMaterial = 60;
            // Especifica que a cor de fundo da janela será preta
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
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
            angle = 45;
        }
        static void EspecificaParametrosVisualizacao()
        {

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(angle, fAspect, 0.4, 500);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        // Função callback chamada quando o tamanho da janela é alterado
        static void AlteraTamanhoJanela(int w, int h)
        {
            if (h == 0) h = 1;
            Gl.glViewport(0, 0, w, h);
            fAspect = (float)w / (float)h;
            EspecificaParametrosVisualizacao();
        }
        static void SpecialKeys(int key, int x, int y)
        {
            switch (key)
            {

                case Glut.GLUT_KEY_LEFT:
                    yLook += 1.0;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    yLook -= 1.0;
                    break;

                case Glut.GLUT_KEY_PAGE_DOWN:
                    xLook -= 1.0;
                    break;
                case Glut.GLUT_KEY_PAGE_UP:
                    xLook += 1.0;
                    break;

                case Glut.GLUT_KEY_HOME:
                    zLook += 1.0;
                    break;
                case Glut.GLUT_KEY_END:
                    zLook -= 1.0;
                    break;
                case Glut.GLUT_KEY_F1:
                    tx += 1.0f;
                    break;
                case Glut.GLUT_KEY_F2:
                    tx -= 1.0f;
                    break;
                case Glut.GLUT_KEY_F3:
                    Gl.glDisable(Gl.GL_LIGHT0);
                    break;
            }
            // Inicializa sistema de coordenadas do modelo
            Gl.glLoadIdentity();
            // Especifica posição do observador e do alvo
            Glu.gluLookAt(xLook, yLook, zLook, 0, 1, 0, 0, 5, 0);
            Glut.glutPostRedisplay();
        }
        // Função callback chamada para gerenciar eventos do mouse
        static void GerenciaMouse(int button, int state, int x, int y)
        {
            if (button == Glut.GLUT_LEFT_BUTTON)
                if (state == Glut.GLUT_DOWN)
                { // Zoom-in
                    if (angle >= 10) angle -= 5;
                }
            if (button == Glut.GLUT_RIGHT_BUTTON)
                if (state == Glut.GLUT_DOWN)
                { // Zoom-out
                    if (angle <= 130) angle += 5;
                }
            EspecificaParametrosVisualizacao();
            Glut.glutPostRedisplay();
        }
        // Programa Principal
        static void Main()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(400, 350);
            Glut.glutCreateWindow("Visualizacao C#");
            Glut.glutDisplayFunc(Desenha);
            Glut.glutReshapeFunc(AlteraTamanhoJanela);
            Glut.glutSpecialFunc(SpecialKeys);
            Glut.glutMouseFunc(GerenciaMouse);
            Inicializa();
            Glut.glutMainLoop();
        }
    }
}