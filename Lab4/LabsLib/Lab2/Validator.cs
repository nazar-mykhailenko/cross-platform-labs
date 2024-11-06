namespace LabsLib.Lab2
{
    public class Validator
    {
        private readonly InputData _inputData;

        public Validator(InputData inputData)
        {
            _inputData = inputData;
            CheckInputIsValid();
        }

        private void CheckInputIsValid()
        {
            if (_inputData.N < 1 || _inputData.N > 100000)
            {
                throw new ArgumentException("N must be between 1 and 1000");
            }

            if (_inputData.K < 1 || _inputData.K > _inputData.N)
            {
                throw new ArgumentException("K must be between 1 and N");
            }

            if (_inputData.W < 1)
            {
                throw new ArgumentException("W must be greater than 0");
            }

            if (_inputData.S < 1 || _inputData.S > _inputData.W)
            {
                throw new ArgumentException("S must be between 1 and W");
            }

            if (_inputData.ForbiddenWeekdays.Count > _inputData.W)
            {
                throw new ArgumentException("Forbidden weekdays count must be less than or equal to W");
            }

            if (_inputData.ForbiddenMonthDays.Count > _inputData.N)
            {
                throw new ArgumentException("Forbidden month days count must be less than or equal to N");
            }

            foreach (int weekday in _inputData.ForbiddenWeekdays)
            {
                if (weekday < 1 || weekday > _inputData.W)
                {
                    throw new ArgumentException("Forbidden weekday must be between 1 and W");
                }
            }

            foreach (int monthDay in _inputData.ForbiddenMonthDays)
            {
                if (monthDay < 1 || monthDay > _inputData.N)
                {
                    throw new ArgumentException("Forbidden month day must be between 1 and N");
                }
            }
        }

        public bool IsValidDay(int day)
        {
            int weekday = (_inputData.S + (day - 1) % _inputData.W - 1) % _inputData.W + 1;

            if (_inputData.ForbiddenWeekdays.Contains(weekday))
            {
                return false;
            }

            if (_inputData.ForbiddenMonthDays.Contains(day))
            {
                return false;
            }

            return true;
        }
    }
}