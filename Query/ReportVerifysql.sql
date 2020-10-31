
IF OBJECT_ID ('tempdb..#VerfyHeader') IS NOT NULL DROP TABLE #VerfyHeader
SELECT 
	vc.ID AS VerifyCustomerID
	,vc.CreateDate
	,vc.PhoneNo
	,null AS PhoneSendOTP
	,vc.CitizenID_TaxID AS CitizenIDTaxID
	,pt.Description AS ProductTypeName
	,st.Description AS ServiceTypeName
	,vt.Description AS VerifyTypeName
	,vc.ResultOfVerify
	,er.Description AS EndCallReasonName
	,vc.CreateBy AS StaffName
INTO #VerfyHeader
FROM VerifyCustomer AS vc
LEFT JOIN Ms_ProductType pt	  ON vc.ProductTypeCode = pt.Code
LEFT JOIN Ms_ServiceType st   ON vc.ServiceTypeCode = st.Code
LEFT JOIN Ms_VerifyType vt	  ON vc.VerifyTypeCode = vt.Code 
LEFT JOIN Ms_EndCallReason er ON vc.EndCallReasonCode = er.Code
WHERE 1=1


SELECT VerifyCustomerID
	,CreateDate
	,PhoneNo
	,PhoneSendOTP
	,CitizenIDTaxID
	,ProductTypeName
	,ServiceTypeName
	,VerifyTypeName
	,ResultOfVerify
	,EndCallReasonName
	,StaffName
FROM #VerfyHeader




SELECT 
	 vq.ID
	,vq.VerifyCustomerID
	,vq.Running
	,vq.Question
	,vq.Answer
	,vq.Result
FROM VerifyQuestion vq
LEFT JOIN #VerfyHeader vhd on vq.VerifyCustomerID=vhd.VerifyCustomerID
WHERE vhd.VerifyCustomerID IS NOT NULL



DROP TABLE #VerfyHeader