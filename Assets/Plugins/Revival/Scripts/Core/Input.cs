namespace Revival
{
    public static class Input
    {
        public static IInput Instance = new MemoryInputLogger(new DefaultInput());

        public static void Replay()
        {
            if (Instance is IInputLogger)
            {
                var logger = (IInputLogger) Instance;
                Instance = new MemoryInputReplayer(logger);
            }

            Instance.Start();
        }

        public static void Record()
        {
            var logger = new MemoryInputLogger(new DefaultInput());
            Instance = logger;
            logger.Start();
        }
    }
}