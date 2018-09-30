# CarrierPidgeon

[![Build Status](https://dev.azure.com/dillon-adams/GitHub/_apis/build/status/CarrierPidgeon)](https://dev.azure.com/dillon-adams/GitHub/_build/latest?definitionId=5)

Carrier Pidgeon is a cross platform integration layer. The core functionality provides for both event driven and batch driven interfaces. Once the software is up an running it scans a directory for compiled interfaces that implement the ```IInterface<TSender, TReceiver>``` interface. This allows new interfaces to be added with ease.

Each interface is composed of two components, a sender and a receiver. These implementations are provided by technology specific assemblies provided along with the Carrier Pidgeon software. Ideally, the Extract and Load portions of the ETL (Extract/Transform/Load) process would be handled by the Carrier Pidgeon software and the dynamically loaded libraries would just handle any transformation between the received and expected format.