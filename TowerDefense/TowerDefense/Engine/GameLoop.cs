using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TowerDefense.Engine
{
    public class GameLoop
    {
        
        const int SkipTicks = 1000 / Settings.TicksPerSecond;
        const int MaxFrameSkip = 10;

        private readonly PictureBox _pictureBox;
        private readonly Game _game;
        private readonly Device _device;
        private readonly BackgroundWorker _loopThread;

        public GameLoop(Game game, PictureBox pictureBox)
        {
            _loopThread = new BackgroundWorker();
            _loopThread.DoWork += _loopThread_DoWork;

            _pictureBox = pictureBox;
            _pictureBox.Paint += _pictureBox_Paint;

            _device = new Device(_pictureBox);

            _game = game;
            _game.Initialize(_device);
        }

        public Game Game
        {
            get { return _game; }
        }

        public void Start()
        {
            _loopThread.RunWorkerAsync();
        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }

        private void Update()
        {
            _game.Update();
        }

        private void Draw()
        {
            _pictureBox.Invoke(new MethodInvoker(() => _pictureBox.Refresh()));
        }

        void _loopThread_DoWork(object sender, DoWorkEventArgs e)
        {
            _game.Start();
            long nextGameTick = getTickCount();
            const bool gameIsRunning = true;

            while (gameIsRunning)
            {
                int loops = 0;
                while (getTickCount() > nextGameTick && loops < MaxFrameSkip)
                {
                    Update();

                    nextGameTick += SkipTicks;
                    loops++;
                }

                Draw();
            }
        }


        void _pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _game.Draw(e.Graphics);
        }

        private long getTickCount()
        {
            return (long) (new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds);
        }
    }
}
