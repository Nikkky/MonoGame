using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Effect effect;
        // массив вершин
        VertexPositionColor[] vertexList;

        // описание формата вершин
        VertexDeclaration vertexDeclaration;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // создать массив-контейнер для хранения трёх вершин
            vertexList = new VertexPositionColor[3];

            effect = Content.Load<Effect>("Effect");

            // создать в массиве вершин три вершины типа VertexPositionColor описывающих 3D-треугольник
            vertexList[0] = new VertexPositionColor(new Vector3(0, 0.5f, 0), Color.Gray);
            vertexList[1] = new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0), Color.Gray);
            vertexList[2] = new VertexPositionColor(new Vector3(0.5f, -0.5f, 0), Color.Gray);

            // создать описание формата вершин
            vertexDeclaration = new VertexDeclaration(VertexPositionTexture.VertexDeclaration.GetVertexElements());
                        

            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            graphics.GraphicsDevice.Clear(Color.Blue);

            // начать отрисовку первого прохода
            effect.CurrentTechnique.Passes[0].Apply();

            // отключить отсечение невидимых поверхностей
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // нарисовать треугольник используя массив вершин
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
                           (PrimitiveType.TriangleList, vertexList, 0, 1);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
