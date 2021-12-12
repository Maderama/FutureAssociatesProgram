//=============================================================================
// Testing created for Mantel Group Future Associates Program Interview 13.12.2021
// @author: Madison Beare
//=============================================================================
using Xunit;
using System.Text.RegularExpressions.Mantel_Group;
using System;

public class testclass
{
    [Fact]
    // Tests the number of valid, unique IP Addresses found. This tests the Regex pattern. 
    public void TestingIPAddressRegex()
    {
        Program IPAddressProgram = new Program();
        IPAddressProgram.UniqueIPAddresses();
        IPAddressProgram.UniqueIPAddressCount();
        Assert.Equal(5, IPAddressProgram.UniqueIPAddressCount());
    }

    [Fact]
    // Tests the number of valid, uniqu URLs obtained. This tests the Regex pattern.
    public void TestingURLsRegex()
    {
        Program urlProgram = new Program();
        urlProgram.TopThreeURLs();
        urlProgram.NumberOfURLsFound();
        Assert.Equal(2, urlProgram.NumberOfURLsFound());
    }

    [Fact]
    public void IPAddressMethodDoesNotThrowError()
    {
        try
        {
            Program uniqueIPs = new Program();
            uniqueIPs.UniqueIPAddressCount();
            return; // indicates success
        }
        catch (System.FormatException)
        {
            Assert.True(false, "Error Message");
        }
    }

    [Fact]
    public void URLsMethodDoesNotThrowError()
    {
        try
        {
            Program urlProgram = new Program();
            urlProgram.TopThreeURLs();
            return; // indicates success
        }
        catch (System.FormatException)
        {
            Assert.True(false, "Error Message");
        }
    }

    [Fact]
    public void MostActiveIPsDoesNotThrowError()
    {
        try
        {
            Program mostActiveIPs = new Program();
            mostActiveIPs.MostActiveIPAddresses();
            return; // indicates success
        }
        catch (System.FormatException)
        {
            Assert.True(false, "Error Message");
        }
    }
}