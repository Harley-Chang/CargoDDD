# Architecture Decision Record
## Architecture
- Domain Design Driver
- CQRS
- SOLID
- ES

## Building Blocks
### XUnit & TestServer
#### HealthChecks
无法检测到HC.WebApi中的HealthChecks管道配置，需要在IntegrationTest的Arrange中模拟AddHealthChecks & MapHealthChecks
#### TestFixture
测试固定配置，WebHost使用固定Startup类进行配置服务与管道