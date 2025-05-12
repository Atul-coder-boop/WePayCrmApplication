using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Sql.Queries
{
    public class LeadsQueries
    {
        public static string AddNewLeads =>
            @"INSERT INTO [LeadsMst] ([CustomerName], [Email], [PhoneNo], [LoanRequired],[Purpose],[Tenure],[MonthlyIncome],[SalaryMode],[city],[State],[PinCode],[UtmSource],[Domain],[Status],[IP],[LoanCount],[GCLID],[ConversionName],[LeadAssigneeId],[CreditManagerId]) 
				VALUES (@CustomerName, @Email, @PhoneNo, @LoanRequired,@Purpose,@Tenure,@MonthlyIncome,@SalaryMode,@city,@State,@PinCode,@UtmSource,@Domain,@Status,@IP,@LoanCount,@GCLID,@ConversionName,@LeadAssigneeId,@CreditManagerId)";

        public static string GetRandomCredManagerID =>
            @"SELECT TOP 1 CredMgrId FROM creditmgrmst
              ORDER BY NEWID()";

        public static string GetrandomTelecallerId =>
            @"SELECT TOP 1 CallerID FROM TelecallerMst
             ORDER BY NEWID()";

        public static string GetFresLeadsdata =>
            @"select tm.CallerName,cm.CredMgrName,lm.CustomerName,lm.CustomerId,lm.Email,lm.PhoneNo,
            lm.LoanRequired,lm.Purpose,lm.Tenure,lm.MonthlyIncome,lm.SalaryMode,
            lm.city,lm.State,lm.PinCode,lm.UtmSource,lm.Domain,lm.Status,lm.IP,
            lm.CreatedAt,lm.UpdatedAt,lm.LoanCount,lm.GCLID,lm.ConversionName,lm.ConversionTime,lm.CreatedAt,lm.UpdatedAt from LeadsMst as lm
            left join creditmgrmst as cm on lm.CreditManagerId=cm.CredMgrId
            left join TelecallerMst tm on lm.LeadAssigneeId=tm.CallerId";


        public static string GetFresLeadsdataByID =>
          @"select tm.CallerName,cm.CredMgrName,lm.CustomerName,lm.CustomerId,lm.Email,lm.PhoneNo,
            lm.LoanRequired,lm.Purpose,lm.Tenure,lm.MonthlyIncome,lm.SalaryMode,
            lm.city,lm.State,lm.PinCode,lm.UtmSource,lm.Domain,lm.Status,lm.IP,
            lm.CreatedAt,lm.UpdatedAt,lm.LoanCount,lm.GCLID,lm.ConversionName,lm.ConversionTime from LeadsMst as lm
            left join creditmgrmst as cm on lm.CreditManagerId=cm.CredMgrId
            left join TelecallerMst tm on lm.LeadAssigneeId=tm.CallerId where lm.CustomerId=@CustomerId";

        public static string UpdateloanApplicationDetails = @"update LeadsMst set Purpose=@Purpose ,MonthlyIncome=@MonthlyIncome, LoanRequired=@LoanRequired,city=@city,PinCode=@PinCode,State=@State where CustomerId=@CustomerId";

        public static string InsertCustomerAddress = @"insert into  customerAddres_mst (customerId,Type,Address,State,City,Pincode,HouseType,Status) 
                             values(@customerId,@Type,@Address,@State,@City,@Pincode,@HouseType,@Status)";

        public static string GetCustomerAddressbyID = @"select ca.customerId,ca.Type,ca.Address,ist.[Name] as State,ca.City,ca.Pincode,ca.HouseType,st.Label as status from customerAddres_mst  as ca
left join IndianStates_mst as ist  on ist.Id=ca.State
left join CallingStatus  as st on st.id  =ca.Status  where ca.customerId=@customerid";
    }
}
