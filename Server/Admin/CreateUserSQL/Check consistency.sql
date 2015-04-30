-- for every consumer and adapter there should be ConsumerAdapters row
select * from (
select 
cast (A.Id as nvarchar(100)) + ':' + cast (C.Id as nvarchar(100)) as ACId,
A.Id as AdapterID, A.Name as AdapterName,
C.Id as ConsumerID, C.Name as ConsumerName
from Consumers C, Adapters  A
) T
where ACId IN
(
select ACId from
(
select 
cast (A.Id as nvarchar(100)) + ':' + cast (C.Id as nvarchar(100)) as ACId
from Consumers C, Adapters  A
) T
where ACId not in (
select cast (AdapterId as nvarchar(100)) + ':' + cast (ConsumerId as nvarchar(100)) as ACId from ConsumerAdapters
)
)

-- Accounts should have ConsumerID
select * from Accounts where ConsumerId is null

-- There should be an account per Customer
select * from Consumers where ID not in 
(select ConsumerId from Accounts where ConsumerId is not null )

-- for every service and account there should be ConsumerAdapters row
select * from (
select 
cast (A.Id as nvarchar(100)) + ':' + cast (S.Id as nvarchar(100)) as ASId,
A.Id as AccountID, A.Name as AccountName,
S.Id as ServiceID, S.Name as ServiceName
from [Services] S, Accounts  A
) T
where ASId IN
(
select ASId from
(
select 
cast (A.Id as nvarchar(100)) + ':' + cast (S.Id as nvarchar(100)) as ASId
from [Services] S, Accounts  A
) T
where ASId not in (
select cast (AccountID as nvarchar(100)) + ':' + cast (ServiceID as nvarchar(100)) as ASId from ServiceAccounts
)
)

