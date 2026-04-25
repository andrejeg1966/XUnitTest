using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using Xunit;

//https://www.youtube.com/watch?v=aq3IbO0RwAQ&list=PL82C6-O4XrHeyeJcI5xrywgpfbrqdkQd4&index=1
//https://github.com/teddysmithdev/RunGroop

using FakeItEasy;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTests
    {
        
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;

        public NetworkServiceTests()
        {
            //Dependcias, fake the class
            _dNS = A.Fake<IDNS>();

            //SUT
            _pingService = new NetworkService(_dNS);
        }
        

        [Fact]
        public void NetwNetworkService_SendPing_ReturnString()
        {
            //Arange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);  //fake der Returnwert true von SendDNS()

            //Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Succes: Ping Sent!");
            result.Should().Contain("Succes", Exactly.Once());
        }

        //test integer with parametrized test
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetwNetworkService_TimeOut_ReturnInt(int i, int j, int expected)
        {
            //Arange
       
            //Act
            var result = _pingService.TimeOut(i, j);

            //Assert
            result.Should().Be(expected);

        }

        [Fact]
        public void NetwNetworkService_LastPingDate_ReturnDate()
        {
            //Arange

            //Act
            var result = _pingService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.February(2010));
            result.Should().BeBefore(2.March(2030));
        }

        [Fact]
        public void NetwNetworkService_GetPingOptions_ReturnObject()
        {
            //Arange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(expected.Ttl);
            
        }

        [Fact]
        public void NetwNetworkService_GetPingOptionsList_ReturnObjects()
        {
            //Arange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _pingService.GetPingOptionsList();

            //Assert
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
