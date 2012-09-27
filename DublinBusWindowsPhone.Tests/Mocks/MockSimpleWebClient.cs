

namespace DublinBusWindowsPhone.Tests.Mocks
{
    using System;
    using System.Net;
    using System.Reflection;

    public class MockSimpleWebClient 
    {
        public void UploadStringAsync(Uri address, string data)
        {
            ConstructorInfo ctor = typeof(UploadStringCompletedEventArgs).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
            var mockedEventArgs = (UploadStringCompletedEventArgs)ctor.Invoke(new object[] { this.testResponse, null, false, null });
            mockedEventArgs.GetType().GetField("m_Result", BindingFlags.NonPublic).SetValue(mockedEventArgs, this.testResponse);

            if (this.UploadStringCompleted != null)
            {
                this.UploadStringCompleted(this, mockedEventArgs);
            }
        }

        public event UploadStringCompletedEventHandler UploadStringCompleted;

        private readonly string testResponse =
        @"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
              <soap:Body>
                <GetRealTimeStopDataResponse xmlns=""http://dublinbus.ie/"">
                  <GetRealTimeStopDataResult>
                    <xs:schema id=""NewDataSet"" xmlns="""" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">
                      <xs:element name=""NewDataSet"" msdata:IsDataSet=""true"" msdata:MainDataTable=""StopData"" msdata:UseCurrentLocale=""true"">
                        <xs:complexType>
                          <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">
                            <xs:element name=""StopData"">
                              <xs:complexType>
                                <xs:sequence>
                                  <xs:element name=""ServiceDelivery_ResponseTimestamp"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""ServiceDelivery_ProducerRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""ServiceDelivery_Status"" type=""xs:boolean"" minOccurs=""0"" />
                                  <xs:element name=""ServiceDelivery_MoreData"" type=""xs:boolean"" minOccurs=""0"" />
                                  <xs:element name=""StopMonitoringDelivery_Version"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""StopMonitoringDelivery_ResponseTimestamp"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""StopMonitoringDelivery_RequestMessageRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredStopVisit_RecordedAtTime"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredStopVisit_MonitoringRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_LineRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_DirectionRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""FramedVehicleJourneyRef_DataFrameRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""FramedVehicleJourneyRef_DatedVehicleJourneyRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_PublishedLineName"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_OperatorRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_DestinationRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_DestinationName"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_Monitored"" type=""xs:boolean"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_InCongestion"" type=""xs:boolean"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_BlockRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredVehicleJourney_VehicleRef"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_VisitNumber"" type=""xs:string"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_VehicleAtStop"" type=""xs:boolean"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_AimedArrivalTime"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_ExpectedArrivalTime"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_AimedDepartureTime"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""MonitoredCall_ExpectedDepartureTime"" type=""xs:dateTime"" minOccurs=""0"" />
                                  <xs:element name=""Timestamp"" type=""xs:dateTime"" minOccurs=""0"" />
                                </xs:sequence>
                              </xs:complexType>
                            </xs:element>
                          </xs:choice>
                        </xs:complexType>
                      </xs:element>
                    </xs:schema>
                    <diffgr:diffgram xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"" xmlns:diffgr=""urn:schemas-microsoft-com:xml-diffgram-v1"">
                      <DocumentElement xmlns="""">
                        <StopData diffgr:id=""StopData1"" msdata:rowOrder=""0"">
                          <ServiceDelivery_ResponseTimestamp>2012-09-25T21:10:01.143+01:00</ServiceDelivery_ResponseTimestamp>
                          <ServiceDelivery_ProducerRef>bac</ServiceDelivery_ProducerRef>
                          <ServiceDelivery_Status>true</ServiceDelivery_Status>
                          <ServiceDelivery_MoreData>false</ServiceDelivery_MoreData>
                          <StopMonitoringDelivery_Version>1.0</StopMonitoringDelivery_Version>
                          <StopMonitoringDelivery_ResponseTimestamp>2012-09-25T21:10:01.147+01:00</StopMonitoringDelivery_ResponseTimestamp>
                          <StopMonitoringDelivery_RequestMessageRef>0</StopMonitoringDelivery_RequestMessageRef>
                          <MonitoredStopVisit_RecordedAtTime>2012-09-25T21:10:01.147+01:00</MonitoredStopVisit_RecordedAtTime>
                          <MonitoredStopVisit_MonitoringRef>01377</MonitoredStopVisit_MonitoringRef>
                          <MonitoredVehicleJourney_LineRef>69</MonitoredVehicleJourney_LineRef>
                          <MonitoredVehicleJourney_DirectionRef>Inbound</MonitoredVehicleJourney_DirectionRef>
                          <FramedVehicleJourneyRef_DataFrameRef>2012-09-25</FramedVehicleJourneyRef_DataFrameRef>
                          <FramedVehicleJourneyRef_DatedVehicleJourneyRef>1975</FramedVehicleJourneyRef_DatedVehicleJourneyRef>
                          <MonitoredVehicleJourney_PublishedLineName>68</MonitoredVehicleJourney_PublishedLineName>
                          <MonitoredVehicleJourney_OperatorRef>bac</MonitoredVehicleJourney_OperatorRef>
                          <MonitoredVehicleJourney_DestinationRef>05190</MonitoredVehicleJourney_DestinationRef>
                          <MonitoredVehicleJourney_DestinationName>Hawkins St via Sth Circular Rd</MonitoredVehicleJourney_DestinationName>
                          <MonitoredVehicleJourney_Monitored>true</MonitoredVehicleJourney_Monitored>
                          <MonitoredVehicleJourney_InCongestion>false</MonitoredVehicleJourney_InCongestion>
                          <MonitoredVehicleJourney_BlockRef>068001:34</MonitoredVehicleJourney_BlockRef>
                          <MonitoredVehicleJourney_VehicleRef>38062</MonitoredVehicleJourney_VehicleRef>
                          <MonitoredCall_VisitNumber>49</MonitoredCall_VisitNumber>
                          <MonitoredCall_VehicleAtStop>false</MonitoredCall_VehicleAtStop>
                          <MonitoredCall_AimedArrivalTime>2012-09-25T21:37:42+01:00</MonitoredCall_AimedArrivalTime>
                          <MonitoredCall_ExpectedArrivalTime>2012-09-25T21:36:58+01:00</MonitoredCall_ExpectedArrivalTime>
                          <MonitoredCall_AimedDepartureTime>2012-09-25T21:37:42+01:00</MonitoredCall_AimedDepartureTime>
                          <MonitoredCall_ExpectedDepartureTime>2012-09-25T21:36:58+01:00</MonitoredCall_ExpectedDepartureTime>
                          <Timestamp>2012-09-25T21:09:43.873+01:00</Timestamp>
                        </StopData>
                        <StopData diffgr:id=""StopData2"" msdata:rowOrder=""1"">
                          <ServiceDelivery_ResponseTimestamp>2012-09-25T21:10:01.143+01:00</ServiceDelivery_ResponseTimestamp>
                          <ServiceDelivery_ProducerRef>bac</ServiceDelivery_ProducerRef>
                          <ServiceDelivery_Status>true</ServiceDelivery_Status>
                          <ServiceDelivery_MoreData>false</ServiceDelivery_MoreData>
                          <StopMonitoringDelivery_Version>1.0</StopMonitoringDelivery_Version>
                          <StopMonitoringDelivery_ResponseTimestamp>2012-09-25T21:10:01.147+01:00</StopMonitoringDelivery_ResponseTimestamp>
                          <StopMonitoringDelivery_RequestMessageRef>0</StopMonitoringDelivery_RequestMessageRef>
                          <MonitoredStopVisit_RecordedAtTime>2012-09-25T21:10:01.147+01:00</MonitoredStopVisit_RecordedAtTime>
                          <MonitoredStopVisit_MonitoringRef>01377</MonitoredStopVisit_MonitoringRef>
                          <MonitoredVehicleJourney_LineRef>123</MonitoredVehicleJourney_LineRef>
                          <MonitoredVehicleJourney_DirectionRef>Outbound</MonitoredVehicleJourney_DirectionRef>
                          <FramedVehicleJourneyRef_DataFrameRef>2012-09-25</FramedVehicleJourneyRef_DataFrameRef>
                          <FramedVehicleJourneyRef_DatedVehicleJourneyRef>5462</FramedVehicleJourneyRef_DatedVehicleJourneyRef>
                          <MonitoredVehicleJourney_PublishedLineName>123</MonitoredVehicleJourney_PublishedLineName>
                          <MonitoredVehicleJourney_OperatorRef>bac</MonitoredVehicleJourney_OperatorRef>
                          <MonitoredVehicleJourney_DestinationRef>01490</MonitoredVehicleJourney_DestinationRef>
                          <MonitoredVehicleJourney_DestinationName>Marino via O'Connell Street</MonitoredVehicleJourney_DestinationName>
                          <MonitoredVehicleJourney_Monitored>true</MonitoredVehicleJourney_Monitored>
                          <MonitoredVehicleJourney_InCongestion>false</MonitoredVehicleJourney_InCongestion>
                          <MonitoredVehicleJourney_BlockRef>123004:34</MonitoredVehicleJourney_BlockRef>
                          <MonitoredVehicleJourney_VehicleRef>38050</MonitoredVehicleJourney_VehicleRef>
                          <MonitoredCall_VisitNumber>18</MonitoredCall_VisitNumber>
                          <MonitoredCall_VehicleAtStop>false</MonitoredCall_VehicleAtStop>
                          <MonitoredCall_AimedArrivalTime>2012-09-25T21:52:00+01:00</MonitoredCall_AimedArrivalTime>
                          <MonitoredCall_ExpectedArrivalTime>2012-09-25T21:52:00+01:00</MonitoredCall_ExpectedArrivalTime>
                          <MonitoredCall_AimedDepartureTime>2012-09-25T21:52:00+01:00</MonitoredCall_AimedDepartureTime>
                          <MonitoredCall_ExpectedDepartureTime>2012-09-25T21:52:00+01:00</MonitoredCall_ExpectedDepartureTime>
                          <Timestamp>2012-09-25T21:09:43.887+01:00</Timestamp>
                        </StopData>
                      </DocumentElement>
                    </diffgr:diffgram>
                  </GetRealTimeStopDataResult>
                </GetRealTimeStopDataResponse>
              </soap:Body>
            </soap:Envelope>
            ";
    }
}
