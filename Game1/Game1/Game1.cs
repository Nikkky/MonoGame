using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        BasicEffect basicEffect;
        RenderTarget2D renderTarget;
        Matrix rendertargetProjectionMatrix;

        DepthStencilState depth = new DepthStencilState() { DepthBufferEnable = true };
        Effect effect;
        Texture2D texture;
        // массив вершин
        VertexPositionColor[] vertexList;
        VertexPositionColor[] vertexList2;
        VertexPositionColor[] vertexList3;

        // описание формата вершин
        VertexDeclaration vertexDeclaration;

        int width = 600, height = 600;
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

            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();


            /////////////////////////////////////////////////////////////////
            device = graphics.GraphicsDevice;

            basicEffect = new BasicEffect(device);

            vertexList = new VertexPositionColor[4];
            vertexList2 = new VertexPositionColor[4];
            vertexList3 = new VertexPositionColor[4];

            effect = Content.Load<Effect>("Effect");

            vertexList[0] = new VertexPositionColor(new Vector3(-0.5f, 0.5f, 0), Color.Red);
            vertexList[1] = new VertexPositionColor(new Vector3(0.5f, 0.5f, 0), Color.Red);
            vertexList[2] = new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0), Color.Red);
            vertexList[3] = new VertexPositionColor(new Vector3(0.5f, -0.5f, 0), Color.Red);

            vertexList2[0] = new VertexPositionColor(new Vector3(-0.35f, 0.65f, 0), Color.Green);
            vertexList2[1] = new VertexPositionColor(new Vector3(0.65f, 0.65f, 0), Color.Green);
            vertexList2[2] = new VertexPositionColor(new Vector3(-0.35f, -0.35f, 0), Color.Green);
            vertexList2[3] = new VertexPositionColor(new Vector3(0.65f, -0.35f, 0), Color.Green);

            vertexList3[0] = new VertexPositionColor(new Vector3(-0.2f, 0.8f, 0), Color.Blue);
            vertexList3[1] = new VertexPositionColor(new Vector3(0.8f, 0.8f, 0), Color.Blue);
            vertexList3[2] = new VertexPositionColor(new Vector3(-0.2f, -0.2f, 0), Color.Blue);
            vertexList3[3] = new VertexPositionColor(new Vector3(0.8f, -0.2f, 0), Color.Blue);


            // создать описание формата вершин
            vertexDeclaration = new VertexDeclaration(VertexPositionTexture.VertexDeclaration.GetVertexElements());
            spriteBatch = new SpriteBatch(device);

            PresentationParameters pp = device.PresentationParameters;

            renderTarget = new RenderTarget2D(device, width, height);
            rendertargetProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)width / (float)height, 0.5f, 100.0f);
            /////////////////////////////////////////////////////////////////




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

            ////

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            
            device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.CornflowerBlue, 1, 0);
            device.SetRenderTarget(renderTarget);
            ///////////////////////////////////////////////////////
            // начать отрисовку первого прохода
            effect.CurrentTechnique.Passes[0].Apply();

            // отключить отсечение невидимых поверхностей
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // нарисовать треугольник используя массив вершин
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertexList, 0, 2);
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertexList2, 0, 2);
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertexList3, 0, 2);
            // TODO: Add your drawing code here
            ///////////////////////////////////////////////////////
            Texture2D resolvedTexture = (Texture2D)renderTarget;
            //device.SetRenderTarget(null);

            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, width, height), Color.Cyan);
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}

