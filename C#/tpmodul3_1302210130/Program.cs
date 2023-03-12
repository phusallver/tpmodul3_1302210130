
internal class Program
{
    class KodePos
    {
        public enum Kelurahan
        {
            Batununggal, Kujangsari,
            Mengger, Wates, Cijaura,
            Jatisari, Margasari,
            Sekejati, Kebonwaru,
            Maleer, Samoja
        }
        private static int getKodePos(Kelurahan lurah)
        {
            int[] kodePos = {40266,
            40287, 40267, 40256,
            40287, 40286, 40286,
            40286, 40272, 40274,
            40273};
            return kodePos[(int)lurah];
        }
        /*private static void Main(string[] args)
        {
            System.Console.WriteLine(getKodePos(Kelurahan.Kujangsari));
        }*/
    }
    public enum DoorState {TERBUKA, TERKUNCI}
    public enum Trigger {BukaPintu, TutupPintu}
    class DoorMachine
    {
        class transition
        {
            public DoorState stateAwal;
            public DoorState stateAkhir;
            public Trigger trigger;

            public transition(DoorState stateAwal, DoorState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }
        transition[] transitions =
        {
            new transition(DoorState.TERBUKA, DoorState.TERBUKA, Trigger.BukaPintu),
            new transition(DoorState.TERBUKA, DoorState.TERKUNCI, Trigger.TutupPintu),
            new transition(DoorState.TERKUNCI, DoorState.TERBUKA, Trigger.BukaPintu),
            new transition(DoorState.TERKUNCI, DoorState.TERKUNCI, Trigger.TutupPintu)
        };
        public DoorState getNextState(DoorState prevState, Trigger trigger)
        {
            DoorState nextState = prevState;
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].stateAwal == prevState && transitions[i].trigger == trigger)
                    nextState = transitions[i].stateAkhir;
            }
            return nextState;  
        }
        public DoorState currentState = DoorState.TERKUNCI;
        public void activateTrigger(Trigger trigger)
        {
            currentState = getNextState(currentState, trigger);
            if (currentState == DoorState.TERKUNCI)
            {
                System.Console.WriteLine("Pintu terkunci");
            }
            else
            {
                System.Console.WriteLine("Pintu tidak terkunci");
            }
        }
        private static void Main(string[] args)
        {
            DoorMachine pintu = new DoorMachine();
            System.Console.WriteLine("Sekarang pintu "+pintu.currentState);
            System.Console.WriteLine("Membuka pintu...");
            pintu.activateTrigger(Trigger.BukaPintu);
        }

    }
}


