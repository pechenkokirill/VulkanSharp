using System;

namespace VulkanSharp
{
	public struct Bool32
	{
		readonly uint _value;

		public Bool32 (bool bValue)
		{
			_value = bValue ? 1u : 0;
		}

		public static implicit operator Bool32 (bool bValue)
		{
			return new Bool32 (bValue);
		}

		public static implicit operator bool (Bool32 bValue)
		{
			return bValue._value != 0;
		}
	}

	public struct DeviceSize
	{
		ulong _value;

		public static implicit operator DeviceSize (ulong iValue)
		{
			return new DeviceSize { _value = iValue };
		}

		public static implicit operator DeviceSize (uint iValue)
		{
			return new DeviceSize { _value = iValue };
		}

		public static implicit operator DeviceSize (int iValue)
		{
			return new DeviceSize { _value = (ulong)iValue };
		}

		public static implicit operator ulong (DeviceSize size)
		{
			return size._value;
		}
	}

	public class ResultException : Exception
	{
		public Result _result;

		public Result Result => _result;

		public ResultException (Result res)
		{
			_result = res;
		}
	}

	public class Version
	{
		public static uint Make (uint major, uint minor, uint patch)
		{
			return (major << 22) | (minor << 12) | patch;
		}

		public static string ToString (uint version)
		{
			return $"{version >> 22}.{(version >> 12) & 0x3ff}.{version & 0xfff}";
		}
	}
}

