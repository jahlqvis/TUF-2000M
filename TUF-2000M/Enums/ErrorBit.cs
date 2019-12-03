namespace TUF_2000M
{
    enum ErrorBit
    {
        None = 0b_0000_0000_0000_0000, // 0
        NoReceivedSignal = 0b_0000_0000_0000_0001, // 0
        LowReceivedSignal = 0b_0000_0000_0000_0010, // 1
        PoorReceivedSignal = 0b_0000_0000_0000_0100, // 2
        PipeEmpty = 0b_0000_0000_0000_1000, // 3

        HardwareFailure = 0b_0000_0000_0001_0000, // 4
        ReceivingCircuitsGainInAdjusting = 0b_0000_0000_0010_0000, // 5
        FrequencyAtTheFrequencyOutputOverFlow = 0b_0000_0000_0100_0000,  // 6
        CurrentAt420mAOverFlow = 0b_0000_0000_1000_0000,  // 7

        RAMchecksumError = 0b_0000_0001_0000_0000,  // 8
        MainClockOrTimerClockError = 0b_0000_0010_0000_0000,  // 9
        ParametersCheckSumError = 0b_0000_0100_0000_0000,  // 10
        ROMCheckSumError = 0b_0000_1000_0000_0000,  // 11

        TemperatureCircuitsError = 0b_0001_0000_0000_0000,  // 12
        Reserved = 0b_0010_0000_0000_0000,  // 13
        InternalTimerOverFlow = 0b_0100_0000_0000_0000,  // 14
        AnalogInputOverRange = 0b_1000_0000_0000_0000,  // 15
    }
}
