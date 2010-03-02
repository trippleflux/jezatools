using System;
using System.Threading;
using System.Windows.Forms;

namespace jeza.Travian.GameCenter
{
    public partial class ProcessCenter : Form
    {
        public ProcessCenter()
        {
            InitializeComponent();
        }

        private void ProcessCenter_Load(object sender, EventArgs e)
        {

        }

        //private void StartThread(object sender, EventArgs e)
        //{
        //    button.Enabled = false;
        //    lock (stateLock)
        //    {
        //        target = rng.Next(100);
        //    }
        //    Thread t = new Thread(ThreadJob);
        //    t.IsBackground = true;
        //    t.Start();
        //}

        //private void ThreadJob()
        //{
        //    MethodInvoker updateCounterDelegate = UpdateCount;
        //    int localTarget;
        //    lock (stateLock)
        //    {
        //        localTarget = target;
        //    }
        //    UpdateStatus("Starting");

        //    lock (stateLock)
        //    {
        //        currentCount = 0;
        //    }
        //    Invoke(updateCounterDelegate);
        //    // Pause before starting
        //    Thread.Sleep(500);
        //    UpdateStatus("Counting");
        //    for (int i = 0; i < localTarget; i++)
        //    {
        //        lock (stateLock)
        //        {
        //            currentCount = i;
        //        }
        //        // Synchronously show the counter
        //        Invoke(updateCounterDelegate);
        //        Thread.Sleep(100);
        //    }
        //    UpdateStatus("Finished");
        //    Invoke(new MethodInvoker(EnableButton));
        //}

        //private void UpdateStatus(string value)
        //{
        //    if (InvokeRequired)
        //    {
        //        // We're not in the UI thread, so we need to call BeginInvoke
        //        BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] {value});
        //        return;
        //    }
        //    // Must be on the UI thread if we've got this far
        //    statusIndicator.Text = value;
        //}

        //private void UpdateCount()
        //{
        //    int tmpCount;
        //    lock (stateLock)
        //    {
        //        tmpCount = currentCount;
        //    }
        //    counter.Text = tmpCount.ToString();
        //}

        //private void EnableButton()
        //{
        //    button.Enabled = true;
        //}
    }
}