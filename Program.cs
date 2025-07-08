using System.Device.Pwm;

class Program
{
    private const int Frequency = 100; // 100 Hz PWM frequency (suitable for vibration motor)

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting PWM vibration motor test...");
            // Create PWM channel (chip 0, channel 0 for GPIO 18)
            using var pwm = PwmChannel.Create(0, 0, Frequency);
            // Create PWM channel (chip 0, channel 1 for GPIO 19)
            using var pwm1 = PwmChannel.Create(0, 1, Frequency);

            // Start PWM
            pwm.Start();

            // Test 1: 25% intensity for 2 seconds
            Console.WriteLine("Test 1: 25% intensity for 2 seconds");
            pwm.DutyCycle = 0.25; // 25% duty cycle
            Thread.Sleep(2000);

            // Test 2: 50% intensity for 2 seconds
            Console.WriteLine("Test 2: 50% intensity for 2 seconds");
            pwm.DutyCycle = 0.50; // 50% duty cycle
            Thread.Sleep(2000);

            // Test 3: 75% intensity for 2 seconds
            Console.WriteLine("Test 3: 75% intensity for 2 seconds");
            pwm.DutyCycle = 0.75; // 75% duty cycle
            Thread.Sleep(2000);

            // Stop PWM
            pwm.Stop();
            Console.WriteLine("PWM test complete.");
        }
        finally
        {
            // Ensure motor is off and pin is closed
            //controller.Write(MotorPin, PinValue.Low);
            //controller.ClosePin(MotorPin);
            Console.WriteLine("Tests complete. Motor stopped.");
        }
    }
}