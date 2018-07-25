namespace Revival
{
    public static class Input
    {
        public static IInput Instance = new MemoryInputLogger(new DefaultInput());
    }
}