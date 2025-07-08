using System.Device.Gpio;
using System.Device.Pwm;

class Program
{
    // GPIO pin connected to the MOSFET gate
    private const int MotorPin = 17;
    private const int PwmPin = 18;
    private const int GpioPin1 = 17;
    private const int GpioPin2 = 18;
    private const int Frequency = 100; // 100 Hz PWM frequency (suitable for vibration motor)

    static void Main(string[] args)
    {
        // Console.WriteLine("Testing GPIO 17 and GPIO 18...");

        // using var controller = new GpioController();
        // controller.OpenPin(GpioPin1, PinMode.Output);
        // controller.OpenPin(GpioPin2, PinMode.Output);

        // try
        // {
        //     // Test GPIO 17 (Motor 1)
        //     Console.WriteLine("Testing GPIO 17: 3x 1s on/off");
        //     for (int i = 0; i < 3; i++)
        //     {
        //         controller.Write(GpioPin1, PinValue.High);
        //         Console.WriteLine("GPIO 17 ON");
        //         Thread.Sleep(1000);
        //         controller.Write(GpioPin1, PinValue.Low);
        //         Console.WriteLine("GPIO 17 OFF");
        //         Thread.Sleep(1000);
        //     }

        //     // Test GPIO 18 (Motor 2)
        //     Console.WriteLine("Testing GPIO 18: 3x 1s on/off");
        //     for (int i = 0; i < 3; i++)
        //     {
        //         controller.Write(GpioPin2, PinValue.High);
        //         Console.WriteLine("GPIO 18 ON");
        //         Thread.Sleep(1000);
        //         controller.Write(GpioPin2, PinValue.Low);
        //         Console.WriteLine("GPIO 18 OFF");
        //         Thread.Sleep(1000);
        //     }
        // }
        // finally
        // {
        //     controller.Write(GpioPin1, PinValue.Low);
        //     controller.Write(GpioPin2, PinValue.Low);
        //     controller.ClosePin(GpioPin1);
        //     controller.ClosePin(GpioPin2);
        //     Console.WriteLine("Test complete. Pins reset.");
        // }
        
        // Console.WriteLine("Starting vibration motor tests...");

        // // Initialize GPIO controller
        // //using var controller = new GpioController();
        // controller.OpenPin(MotorPin, PinMode.Output);

        try
        {
            // Test 1: Continuous vibration for 3 seconds
            // Console.WriteLine("Test 1: Continuous vibration for 3 seconds");
            // controller.Write(MotorPin, PinValue.High);
            // Thread.Sleep(3000);
            // controller.Write(MotorPin, PinValue.Low);
            // Thread.Sleep(1000); // Pause between tests

            // Test 2: Short pulses (200ms on, 200ms off, 5 times)
            // Console.WriteLine("Test 2: Short pulses (5x 200ms on/off)");
            // for (int i = 0; i < 5; i++)
            // {
            //     controller.Write(MotorPin, PinValue.High);
            //     Thread.Sleep(200);
            //     controller.Write(MotorPin, PinValue.Low);
            //     Thread.Sleep(200);
            // }
            // Thread.Sleep(1000); // Pause between tests

            // Test 3: Long pulses (500ms on, 500ms off, 3 times)
            // Console.WriteLine("Test 3: Long pulses (3x 500ms on/off)");
            // for (int i = 0; i < 3; i++)
            // {
            //     controller.Write(MotorPin, PinValue.High);
            //     Thread.Sleep(500);
            //     controller.Write(MotorPin, PinValue.Low);
            //     Thread.Sleep(500);
            // }

            // Test 4: Checkout PWM
            Console.WriteLine("Starting PWM vibration motor test...");
            // Create PWM channel (chip 0, channel 0 for GPIO 18)
            using var pwm = PwmChannel.Create(0, 1, Frequency);

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