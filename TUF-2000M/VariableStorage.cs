using System;
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

    public class VariableStorage
    {
       
        ModbusValue<float> flowRate = new ModbusValue<float>("Flow Rate", "m^3/h");
        ModbusValue<float> energyFlowRate = new ModbusValue<float>("Energy Flow Rate", "GJ/j");
        ModbusValue<float> velocity = new ModbusValue<float>("Velocity", "m/s");
        ModbusValue<float> fluidSoundSpeed = new ModbusValue<float>("Fluid Sound Speed", "m/s");
        ModbusValue<int> positiveAccumulator = new ModbusValue<int>("Positive accumulator", "");
        ModbusValue<float> positiveDecimalFraction = new ModbusValue<float>("Positive decimal fraction", "");
        ModbusValue<int> negativeAccumulator = new ModbusValue<int>("Negative accumulator", "");
        ModbusValue<float> negativeDecimalFraction = new ModbusValue<float>("Negative decimal fraction", "");
        ModbusValue<int> positiveEnergyAccumulator = new ModbusValue<int>("Positive energy accumulator", "");
        ModbusValue<float> positiveEnergyDecimalFraction = new ModbusValue<float>("Positive energy decimal fraction", "");
        ModbusValue<int> negativeEnergyAccumulator = new ModbusValue<int>("Negative energy accumulator", "");
        ModbusValue<float> negativeEnergyDecimalFraction = new ModbusValue<float>("Negative energy decimal fraction", "");
        ModbusValue<int> netAccumulator = new ModbusValue<int>("Net accumulator", "");
        ModbusValue<float> netDecimalFraction = new ModbusValue<float>("Net decimal fraction", "");
        ModbusValue<int> netEnergyAccumulator = new ModbusValue<int>("Net energy accumulator", "");
        ModbusValue<float> netEnergyDecimalFraction = new ModbusValue<float>("Net energy decimal fraction", "");

        ModbusValue<float> temperature1inlet = new ModbusValue<float>("Temperature #1/inlet", "C");
        ModbusValue<float> temperature2inlet = new ModbusValue<float>("Temperature #2/inlet", "C");

        ModbusValue<float> analogInputAI3 = new ModbusValue<float>("Analog input AI3", "");
        ModbusValue<float> analogInputAI4 = new ModbusValue<float>("Analog input AI4", "");
        ModbusValue<float> analogInputAI5 = new ModbusValue<float>("Analog input AI5", "");

        ModbusValue<float> currentInputatAI3 = new ModbusValue<float>("Current input at AI3", "mA");
        ModbusValue<float> currentInputatAI4 = new ModbusValue<float>("Current input at AI4", "mA");
        ModbusValue<float> currentInputatAI5 = new ModbusValue<float>("Current input at AI5", "mA");

        ModbusValue<int> systemPassword = new ModbusValue<int>("System password", "");
        ModbusValue<int> hardwarePassword = new ModbusValue<int>("Password for hardware", "");

        ModbusValue<DateTime> calendar = new ModbusValue<DateTime>("Calendar (date and time)", "");
        ModbusValue<int> autosaveTime = new ModbusValue<int>("Day+Hour for Auto-Save", "");
        ModbusValue<int> keyToInput = new ModbusValue<int>("Key to input", "");
        ModbusValue<int> gotoWindowNr = new ModbusValue<int>("Go to window #", "");

        ModbusValue<int> LCDBacklitLightsSeconds = new ModbusValue<int>("LCD Back-lit lights for number of seconds", "");

        ModbusValue<int> timesForBeeper = new ModbusValue<int>("Times for beeper", "");
        ModbusValue<int> pulsesLeftForOCT = new ModbusValue<int>("Pulses left for OCT", "");
        ModbusValue<ErrorBit> errorOCT = new ModbusValue<ErrorBit>("Error Code", "");

        ModbusValue<float> PT100recistanceOfInlet = new ModbusValue<float>("PT100 recistance of inlet", "Ohm");
        ModbusValue<float> PT100recistanceOfOutlet = new ModbusValue<float>("PT100 recistance of outlet", "Ohm");

        ModbusValue<float> totalTravelTime = new ModbusValue<float>("Total travel time", "Micro-second");
        ModbusValue<float> deltaTravelTime = new ModbusValue<float>("Delta travel time", "Nano-second");
        ModbusValue<float> upstreamTravelTime = new ModbusValue<float>("Upstream travel time", "Micro-second");
        ModbusValue<float> downstreamTravelTime = new ModbusValue<float>("Downstream travel time", "Micro-second");

        ModbusValue<float> outputCurrent = new ModbusValue<float>("Output current", "mA");
        ModbusValue<int> workingStep = new ModbusValue<int>("Working step", "");
        ModbusValue<int> signalQuality = new ModbusValue<int>("Signal Quality", "");
        ModbusValue<int> upstreamStrength = new ModbusValue<int>("Upstream strength", "");
        ModbusValue<int> downstreamStrength = new ModbusValue<int>("Downstream strength", "");

        ModbusValue<int> languageUsed = new ModbusValue<int>("Language used in user interface", "0: English, 1: Chinese");
        ModbusValue<float> travelTimeRatioMeasuredAndCalculated = new ModbusValue<float>("The rate of the measured travel time by the calculated travel time", "Normal 100+-3%");

        ModbusValue<float> reynoldsNumber = new ModbusValue<float>("Reynolds number", "");

        public ModbusValue<float> FlowRate { get => flowRate; set => flowRate = value; }
        public ModbusValue<float> EnergyFlowRate { get => energyFlowRate; set => energyFlowRate = value; }
        public ModbusValue<float> Velocity { get => velocity; set => velocity = value; }
        public ModbusValue<float> FluidSoundSpeed { get => fluidSoundSpeed; set => fluidSoundSpeed = value; }
        public ModbusValue<int> PositiveAccumulator { get => positiveAccumulator; set => positiveAccumulator = value; }
        public ModbusValue<float> PositiveDecimalFraction { get => positiveDecimalFraction; set => positiveDecimalFraction = value; }
        public ModbusValue<int> NegativeAccumulator { get => negativeAccumulator; set => negativeAccumulator = value; }
        public ModbusValue<float> NegativeDecimalFraction { get => negativeDecimalFraction; set => negativeDecimalFraction = value; }
        public ModbusValue<int> PositiveEnergyAccumulator { get => positiveEnergyAccumulator; set => positiveEnergyAccumulator = value; }
        public ModbusValue<float> PositiveEnergyDecimalFraction { get => positiveEnergyDecimalFraction; set => positiveEnergyDecimalFraction = value; }
        public ModbusValue<int> NegativeEnergyAccumulator { get => negativeEnergyAccumulator; set => negativeEnergyAccumulator = value; }
        public ModbusValue<float> NegativeEnergyDecimalFraction { get => negativeEnergyDecimalFraction; set => negativeEnergyDecimalFraction = value; }
        public ModbusValue<int> NetAccumulator { get => netAccumulator; set => netAccumulator = value; }
        public ModbusValue<float> NetDecimalFraction { get => netDecimalFraction; set => netDecimalFraction = value; }
        public ModbusValue<int> NetEnergyAccumulator { get => netEnergyAccumulator; set => netEnergyAccumulator = value; }
        public ModbusValue<float> NetEnergyDecimalFraction { get => netEnergyDecimalFraction; set => netEnergyDecimalFraction = value; }
        public ModbusValue<float> Temperature1inlet { get => temperature1inlet; set => temperature1inlet = value; }
        public ModbusValue<float> Temperature2inlet { get => temperature2inlet; set => temperature2inlet = value; }
        public ModbusValue<float> AnalogInputAI3 { get => analogInputAI3; set => analogInputAI3 = value; }
        public ModbusValue<float> AnalogInputAI4 { get => analogInputAI4; set => analogInputAI4 = value; }
        public ModbusValue<float> AnalogInputAI5 { get => analogInputAI5; set => analogInputAI5 = value; }
        public ModbusValue<float> CurrentInputatAI3 { get => currentInputatAI3; set => currentInputatAI3 = value; }
        public ModbusValue<float> CurrentInputatAI4 { get => currentInputatAI4; set => currentInputatAI4 = value; }
        public ModbusValue<float> CurrentInputatAI5 { get => currentInputatAI5; set => currentInputatAI5 = value; }
        public ModbusValue<int> SystemPassword { get => systemPassword; set => systemPassword = value; }
        public ModbusValue<int> HardwarePassword { get => hardwarePassword; set => hardwarePassword = value; }
        public ModbusValue<DateTime> Calendar { get => calendar; set => calendar = value; }
        public ModbusValue<int> AutosaveTime { get => autosaveTime; set => autosaveTime = value; }
        public ModbusValue<int> KeyToInput { get => keyToInput; set => keyToInput = value; }
        public ModbusValue<int> GotoWindowNr { get => gotoWindowNr; set => gotoWindowNr = value; }
        public ModbusValue<int> LCDBacklitLightsSeconds1 { get => LCDBacklitLightsSeconds; set => LCDBacklitLightsSeconds = value; }
        public ModbusValue<int> TimesForBeeper { get => timesForBeeper; set => timesForBeeper = value; }
        public ModbusValue<int> PulsesLeftForOCT { get => pulsesLeftForOCT; set => pulsesLeftForOCT = value; }
        public ModbusValue<float> PT100recistanceOfInlet1 { get => PT100recistanceOfInlet; set => PT100recistanceOfInlet = value; }
        public ModbusValue<float> PT100recistanceOfOutlet1 { get => PT100recistanceOfOutlet; set => PT100recistanceOfOutlet = value; }
        public ModbusValue<float> TotalTravelTime { get => totalTravelTime; set => totalTravelTime = value; }
        public ModbusValue<float> DeltaTravelTime { get => deltaTravelTime; set => deltaTravelTime = value; }
        public ModbusValue<float> UpstreamTravelTime { get => upstreamTravelTime; set => upstreamTravelTime = value; }
        public ModbusValue<float> DownstreamTravelTime { get => downstreamTravelTime; set => downstreamTravelTime = value; }
        public ModbusValue<float> OutputCurrent { get => outputCurrent; set => outputCurrent = value; }
        public ModbusValue<int> WorkingStep { get => workingStep; set => workingStep = value; }
        public ModbusValue<int> SignalQuality { get => signalQuality; set => signalQuality = value; }
        public ModbusValue<int> UpstreamStrength { get => upstreamStrength; set => upstreamStrength = value; }
        public ModbusValue<int> DownstreamStrength { get => downstreamStrength; set => downstreamStrength = value; }
        public ModbusValue<int> LanguageUsed { get => languageUsed; set => languageUsed = value; }
        public ModbusValue<float> TravelTimeRatioMeasuredAndCalculated { get => travelTimeRatioMeasuredAndCalculated; set => travelTimeRatioMeasuredAndCalculated = value; }
        public ModbusValue<float> ReynoldsNumber { get => reynoldsNumber; set => reynoldsNumber = value; }
        internal ModbusValue<ErrorBit> ErrorOCT { get => errorOCT; set => errorOCT = value; }
    }
}
