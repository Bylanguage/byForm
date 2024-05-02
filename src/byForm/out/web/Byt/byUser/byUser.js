Byt.defineKu("byUser", [ "by", "byExternalSMS", "byLog", "byCommon", "byExternal" ], ($by, $byExternalSMS, $byLog, $byCommon, $byExternal, $byUser) => ({
    enum: {
        confirmUserIsLoginMode: { onlyVerify: 0, verifyLogin: 1 },
        rank: { anonymous: 0, register: 1, vip: 2 },
        safetyCodeMode: { user: 0, mail: 1, mobile: 2 },
        uploadMode: { userIco: 0, contentOther: 1 },
        adminMode: { general: 0, admin: 1 },
        verifyMode: { cookie: 0, session: 1 },
        cer: { 身份证: 0, 护照: 1 }
    },
    object: {
        resultUser: {
            type: class resultUser extends Byt.Object { },
            base: { inherit: $by.object.Result },
            transmit: [ "loginRow", "adminRow" ],
            instance: { props: { loginRow: "byUser.orm.user$userOrm", adminRow: Byt.Row } }
        },
        ByUserStrings: {
            type: class ByUserStrings extends Byt.Object {
                static Format(format, args){
                    if(format == null)
                        return "";
                    if(args == null)
                        args = Byt.Array.$create($by.object.Object, 1, [ 0 ]);
                    for (let i = 0; i < args.length; i++){
                        let arg = args[i];
                        if(arg == null)
                            arg = "";
                        format = format.by$replace("{" + i + "}", arg.by$toString());
                    }
                    return format;
                }
                static Format$1(format, arg1){ return format.by$replace("{0}", arg1 == null ? "" : arg1.by$toString()); }
                static Format$2(format, arg1, arg2){ return format.by$replace("{0}", arg1 == null ? "" : arg1.by$toString()).by$replace("{1}", arg2 == null ? "" : arg2.by$toString()); }
                static Format$3(format, arg1, arg2, arg3){ return $byUser.object.ByUserStrings.Format(format, [ arg1, arg2, arg3 ]); }
                static Format$4(format, arg1, arg2, arg3, arg4){ return $byUser.object.ByUserStrings.Format(format, [ arg1, arg2, arg3, arg4 ]); }
                static getString(ch, en){ return ($byUser.object.ByUserStrings.language || $by.object.System.language) == "en-us" ? en : ch; }
                static Info_IP_Locked_Template(ip, interval){ return $byUser.object.ByUserStrings.Format$2($byUser.object.ByUserStrings.getString("当前IP${0}已经被锁定，锁定时间:${1}分钟!", "The IP {0} has been locked, resting lock interval: {1} minutes."), ip, interval); }
                static Info_Login_MultipleTimes_Locked(interval){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("您当前用户名已经连续登录出错超过5次，当前账号已经被锁定，请${0}小时后再尝试！", "You have input a wrong password 5 times, the current user has been locked, retry after {0} hours."), interval); }
                static Info_Login_MultipleTimes_Will_Lock(interval){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("用户名或密码错误，请重试！连续出错5次则该账号会被锁定{0}分钟！", "Wrong user or password, please agian(error 5 times in a row, the account will be locked for {0} minutes!)"), interval); }
                static Info_Login_Completed(){ return $byUser.object.ByUserStrings.getString("登录成功！", "Login succeed! "); }
                static Info_Illegal_User(){ return $byUser.object.ByUserStrings.getString("用户非法！", "Illegal user, please refresh page and try login again! "); }
                static Info_Freezed_User(){ return $byUser.object.ByUserStrings.getString("当前用户已冻结！", "This user account has been frozen! "); }
                static Info_User_Freezed(){ return $byUser.object.ByUserStrings.getString("当前用户已经被冻结，如想继续使用请联系客服！", "The current user has been frozen. If you want to continue using it, please contact customer service!"); }
                static Info_Annoymous_User_Freezed_Deny_Service(){ return $byUser.object.ByUserStrings.getString("当前匿名用户已经被冻结，服务器拒绝提供服务！", "This annoymous user has been frozen. Server denys to provide any service!"); }
                static Info_Login_Failed_RSA_Missing(){ return $byUser.object.ByUserStrings.getString("没有找到当前session对应的RSA证书，\r\n你需要刷新缓存Ctrl+Shift+delete 并且选中Cookie及其他网站数据项,\r\n或检查你的web端与服务端布署的url是否在同一域下!", "Login failed. the RSA certificate for the current session cannot be found, you need to refresh the cache (Ctrl+Shift+delete) and check Cookies, and check if the URL deployed on your web and server is in the same domain!"); }
                static Info_Login_Failed(){ return $byUser.object.ByUserStrings.getString("登录失败！", "Login failed. "); }
                static Info_Register_Completed_Congratulation(){ return $byUser.object.ByUserStrings.getString("恭喜，注册成功！", "Congratulations! Register Completed!"); }
                static Info_Register_Completed(){ return $byUser.object.ByUserStrings.getString("注册成功！", "Register Completed!"); }
                static Info_Register_Failed(){ return $byUser.object.ByUserStrings.getString("注册失败！", "Register failed "); }
                static Info_Register_Failed_Template(resultInfo){ return Byt.String($byUser.object.ByUserStrings.getString("注册失败：", "Register failed, details: ")) + Byt.String(resultInfo); }
                static Info_Register_UserName_Cannot_Be_Null(){ return $byUser.object.ByUserStrings.getString("用户[user]行 ，f_userRow 不能为空！", "The userName in [user] cannot be null "); }
                static Info_Modify_Completed(){ return $byUser.object.ByUserStrings.getString("修改成功！", "Modify succeed! "); }
                static Info_Modify_Failed_Illegal(){ return $byUser.object.ByUserStrings.getString("当前用户非法，或登录时间过长,修改失败！", "Modify failed, timeout or illegal user, please login and try again. "); }
                static Info_Modify_Failed_Freezed(){ return $byUser.object.ByUserStrings.getString("当前用户已冻结，不允许修改！", "Modify failed, the current user account has been frozen! "); }
                static Info_Modify_Failed_Old_Password_Wrong(){ return $byUser.object.ByUserStrings.getString("原密码错误！", "Modify failed, the inputed original password is wrong. "); }
                static Info_Modify_Failed(){ return $byUser.object.ByUserStrings.getString("修改失败！", "Modify failed! "); }
                static Info_Modify_Failed_Template(resultInfo){ return Byt.String($byUser.object.ByUserStrings.getString("修改失败，", "Modify failed, details: ")) + Byt.String(resultInfo) + Byt.String(Byt.Char("!")); }
                static Info_Reset_Password_Completed(){ return $byUser.object.ByUserStrings.getString("密码重设成功！", "Reset Password succeed! "); }
                static Info_SecurityCode_Invalid(){ return $byUser.object.ByUserStrings.getString("安全码非法", "The security code is invalid."); }
                static Info_SecurityCode_Session_Timeout(){ return $byUser.object.ByUserStrings.getString("会话过期，没有在服务器端找到发送的安全码信息", "Session timeout, cannot find a matching security code in the server."); }
                static Info_SecurityCode_Dismatch(){ return $byUser.object.ByUserStrings.getString("安全码不对！", "The security code dismatches, please try again."); }
                static Info_SecurityCode_Timeout(){ return $byUser.object.ByUserStrings.getString("超时！", "Timeout!."); }
                static Info_SecurityCode_Verification_Succeed(){ return $byUser.object.ByUserStrings.getString("验证成功！", "Verification succeed!"); }
                static Info_SecurityCode_Missing(){ return $byUser.object.ByUserStrings.getString("没有找到安全码信息！", "Cannot find a matching safe code!"); }
                static Info_Cookie_Invalid(f_cookieID){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("非法的cookie ID [{0}] 信息！", "The cookie ID [{0}] is invalid."), f_cookieID); }
                static Info_Password_Pattern_Invalid(){ return $byUser.object.ByUserStrings.getString("密码必须包含数字和字母且长度不得小于8、大于32", "The length of password must be larger than or equal to 8 and smaller than 32, and only digits and letters are valid."); }
                static Info_UserName_Invalid(){ return $byUser.object.ByUserStrings.getString("用户名非法", "The user name is invalid."); }
                static Info_UserName_Invalid_Or_Not_Exist(){ return $byUser.object.ByUserStrings.getString("用户非法或不存在！", "The user name is invalid, or the name does not exist."); }
                static Info_UserName_Invalid_Template(verifyResult){ return Byt.String($byUser.object.ByUserStrings.getString("用户名非法:", "The user name is invalid, details:")) + Byt.String(verifyResult); }
                static Info_UserName_LengthOrPattern_Invalid(){ return $byUser.object.ByUserStrings.getString("用户名长度2-32之间，仅支持数字、字母、下划线", "The length of a user name must be larger than 2 and smaller than 32, and only digits, letters, '_' and surrogates can be used."); }
                static Info_UserName_Length_Invalid(){ return $byUser.object.ByUserStrings.getString("用户名长度不得小于2、大于32", "The length of a user name must be larger than 2 and smaller than 32."); }
                static Info_UserName_Pattern_Invalid(){ return $byUser.object.ByUserStrings.getString("用户名仅支持数字、字母、下划线以及双字节符（中文、韩文、日文等）", "Only digits, letters, '_' and surrogates(such as Chinese letters, korea letters, japanese letters) are supported in user name."); }
                static Info_UserName_Not_Exist(){ return $byUser.object.ByUserStrings.getString("系统不存在这个用户", "The given user name does not exist."); }
                static Info_UserName_Already_Exist(){ return $byUser.object.ByUserStrings.getString("该用户已经存在！", "The given user name already exists."); }
                static Info_Email_Invalid(){ return $byUser.object.ByUserStrings.getString("邮箱格式非法", "The email is invalid."); }
                static Info_Email_Already_Exists(){ return $byUser.object.ByUserStrings.getString("邮箱号码已经存在！", "An account related to the given email is already being used!"); }
                static Info_Email_Too_Long_Or_Too_Short(){ return $byUser.object.ByUserStrings.getString("邮箱最长不超过64个字符,或大于6个字符！", "Email length must be shorter than 64 and longer than 6."); }
                static Info_Email_Format_Invalid(){ return $byUser.object.ByUserStrings.getString("邮箱格式非法", "Email format invalid."); }
                static Info_Email_Format_Invalid_Template(f_mail){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("邮箱[{0}]格式非法", "The format of email [{0}] is invalid."), f_mail); }
                static Info_Email_Not_Exist(){ return $byUser.object.ByUserStrings.getString("系统中不存在这个email", "The given email does not exist an account."); }
                static Info_Email_Freezed(){ return $byUser.object.ByUserStrings.getString("当前邮箱所属的用户已被冻结", "The account belonging to this email has been frozen."); }
                static Info_Phone_Invalid(){ return $byUser.object.ByUserStrings.getString("手机号码格式非法", "The phone number is invalid."); }
                static Info_Phone_Invalid_Or_Not_Exist(){ return $byUser.object.ByUserStrings.getString("手机号非法或不存在！", "The phone number is invalid, or no account is related to the given phone number."); }
                static Info_Phone_Not_Exist(){ return $byUser.object.ByUserStrings.getString("系统不存在这个手机", "No account is related to the given phone number.."); }
                static Info_Phone_Already_Exists(){ return $byUser.object.ByUserStrings.getString("手机号码已经在系统中存在！", "An account related to the given phone number already exists!"); }
                static Info_Phone_Must_11_Digits(){ return $byUser.object.ByUserStrings.getString("手机号码位数必须是11位，必须是数字！", "Phone number must be a 11-digit number"); }
                static Info_Phone_Freezed(){ return $byUser.object.ByUserStrings.getString("当前手机所属的用户已被冻结", "The account belonging to this phone number has been frozen."); }
                static Info_Send_SecurityCode_Mobile(){ return $byUser.object.ByUserStrings.getString("已发送安全码到你的手机，15分钟之内有效！", "A security code has been sent to your phone and is valid for 15 minutes."); }
                static Info_Send_SecurityCode_Mobile_Failed(){ return $byUser.object.ByUserStrings.getString("发送手机短信失败，运营商返回信息：", "Sending security code to your phone failed, info returned by the SMS server: "); }
                static Info_Send_SecurityCode_Email_Config_Missing(){ return $byUser.object.ByUserStrings.getString("没有配置邮件运营商，账号、密码，应在系统第一次启动时配置这些参数", "The mail service provider, account number or password are not configured, these parameters should be configured the first time system start-ups."); }
                static Info_Send_SecurityCode_Email_Title(){ return $byUser.object.ByUserStrings.getString("拜语言密码找回", "By-language password recovery"); }
                static Info_Send_SecurityCode_Email_Content(tmpCodeValue){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("安全码：{0}，有效期15分钟，勿将此码告诉他人，本邮件由系统发送，请勿回复！", "Your security code is: {0}, it will be valid for 15 minutes, please do not share the code. (This email is send from a server, please do not reply to it.)"), tmpCodeValue); }
                static Info_Send_Security_Code_Email_Succeed(f_mail){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("已经往您的邮箱[{0}]发送了安全码！", "A security code has been sent to your email [{0}]."), f_mail); }
                static Info_Send_Security_Code_Email_Failed(f_mail){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("发送安全码失败，邮箱：{0} ", "Failed to send a security code to email {0}."), f_mail); }
                static Info_Send_Security_Code_Failed(){ return $byUser.object.ByUserStrings.getString("发送安全码失败  ", "Failed to send a security code, details:"); }
                static Annoymous_User_Name_Template(rand){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("匿名用户{0}", "Annoymous user {0}"), rand); }
                static Info_RSA_Public_Key_Register_Failed(){ return $byUser.object.ByUserStrings.getString("当前在向服务器注册RSA公钥证书时没有成功,请重新刷新后再次尝试!", "Failed to register a RSA public key to the RSA server, please refresh and retry."); }
                static Info_Upload_Format_Unsupported(formats){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("仅支持上传扩展名为[{0}]格式的文件！", "Only files with extension [{0}] can be uploaded!"), formats); }
                static Info_Upload_File_To_Large(size){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("文件太大，不能大于[{0}]K！", "The file is too large to upload, the maximum is [{0}] KB!"), size); }
                static Info_Upload_File_Only_Allow_Icon(){ return $byUser.object.ByUserStrings.getString("当前仅允许上传用户图标文件！", "Only user icon files are allowed to be uploaded!"); }
                static Info_Upload_User_Not_Login(){ return $byUser.object.ByUserStrings.getString("当前用户还没有登录！", "Cannot upload, please login and retry."); }
                static Info_Upload_Completed(){ return $byUser.object.ByUserStrings.getString("上传成功！", "Upload Completed!"); }
                static Info_Upload_Failed_Template(resultInfo){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("上传失败,原因:[{0}]！", "Upload failed, details: {0}"), resultInfo); }
                static Info_SQL_Execution_Failed(){ return $byUser.object.ByUserStrings.getString("执行SQL失败：", "SQL execution failed, details: "); }
                static Info_Operation_Limited(){ return $byUser.object.ByUserStrings.getString("仅支持：增加与删除！", "Only add and delete operations are allowed!"); }
                static Info_Add_Admin_Succeed(){ return $byUser.object.ByUserStrings.getString("加入管理员成功！", "Adding admin succeeded!"); }
                static Info_Add_Admin_Failed_Template(result){ return $byUser.object.ByUserStrings.Format$1($byUser.object.ByUserStrings.getString("加入管理员失败：{0}！", "Adding admin failed, details: {0}!"), result); }
                static Info_Delete_Admin_Succeed(){ return $byUser.object.ByUserStrings.getString("删除管理员成功！", "Deleting admin succeeded!"); }
                static Info_Delete_Admin_Failed(){ return $byUser.object.ByUserStrings.getString("删除管理员失败！", "Deleting admin failed!"); }
                static Info_Operation_Forbidden_Must_Be_Admin(){ return $byUser.object.ByUserStrings.getString("权限不够，禁止的操作！", "Operation not allowed, please use a admin account and try again!"); }
                static Info_Operation_Forbidden_Only_Admin_Can_Manage(){ return $byUser.object.ByUserStrings.getString("权限不够，禁止进入管理界面！", "Cannot open the manage dialog, please use a admin account and try again!"); }
                static Info_Entered_Passwords_Not_Match(){ return $byUser.object.ByUserStrings.getString("两次输入的新密码不一致！", "The second password does not match the first one!"); }
                static Info_SecurityCode_Not_Valid(){ return $byUser.object.ByUserStrings.getString("请输入发到你手机或邮箱中的安全码，仅支持数字!", "Please enter the security code sent to your phone or email, only digits are allowed."); }
                static Info_SecurityCode_Not_Entered(){ return $byUser.object.ByUserStrings.getString("请填入发送到你手机或邮箱中的验证码后，再尝试该操作！", "Please enter the security code sent to your phone or email and try again!"); }
                static UI_MenuItem_User(){ return $byUser.object.ByUserStrings.getString("用户", "User"); }
                static UI_MenuItem_RegisterUser(){ return $byUser.object.ByUserStrings.getString("注册新用户", "Register as a User"); }
                static UI_MenuItem_Login(){ return $byUser.object.ByUserStrings.getString("登录", "Login"); }
                static UI_MenuItem_ChangePassword(){ return $byUser.object.ByUserStrings.getString("密码修改", "Change password"); }
                static UI_MenuItem_UploadIcon(){ return $byUser.object.ByUserStrings.getString("上传个性头像图标", "Upload an icon"); }
                static UI_MenuItem_Admin(){ return $byUser.object.ByUserStrings.getString("管理员管理", "Admin Management"); }
                static UI_MenuItem_Exit(){ return $byUser.object.ByUserStrings.getString("退出", "Exit"); }
                static UI_user_diLogin_Title(){ return $byUser.object.ByUserStrings.getString("登录", "Login"); }
                static UI_user_diLogin_cLblName_Text(){ return $byUser.object.ByUserStrings.getString("用户名：", "User Name: "); }
                static UI_user_diLogin_cLblPwd_Text(){ return $byUser.object.ByUserStrings.getString("密码：", "Password: "); }
                static UI_user_diLogin_cBtnLogin_Text(){ return $byUser.object.ByUserStrings.getString("登录", "Login"); }
                static UI_user_diLogin_cBtnReg_Text(){ return $byUser.object.ByUserStrings.getString("注册", "Register"); }
                static UI_user_diLogin_cLblFindPwd_Text(){ return $byUser.object.ByUserStrings.getString("忘记密码了？点击找回", "Forgot your password? Click here to retrieve."); }
                static UI_user_diModifPwd_Title(){ return $byUser.object.ByUserStrings.getString("密码修改", "Password Modification"); }
                static UI_user_diModifPwd_cLblSourcePwd_Text(){ return $byUser.object.ByUserStrings.getString("原密码：", "Original password: "); }
                static UI_user_diModifPwd_cLblNewPwd_Text(){ return $byUser.object.ByUserStrings.getString("新密码：", "New password: "); }
                static UI_user_diModifPwd_cLblConfirmNewPwd_Text(){ return $byUser.object.ByUserStrings.getString("请确认新密码：", "Please confirm the new password: "); }
                static UI_user_diModifPwd_cBtnSure_Text(){ return $byUser.object.ByUserStrings.getString("确认", "Confirm"); }
                static UI_user_diModifPwd_cBtnCancel_Text(){ return $byUser.object.ByUserStrings.getString("取消", "Cancel"); }
                static UI_user_diUserReg_Title(){ return $byUser.object.ByUserStrings.getString("用户注册", "User Registration"); }
                static UI_user_diUserReg_cLblName_Text(){ return $byUser.object.ByUserStrings.getString("用户名：", "User Name: "); }
                static UI_user_diUserReg_cLblPwd_Text(){ return $byUser.object.ByUserStrings.getString("密码：", "Password: "); }
                static UI_user_diUserReg_cLblConfirmPwd_Text(){ return $byUser.object.ByUserStrings.getString("再输入一遍：", "Please enter again: "); }
                static UI_user_diUserReg_cLblMobile_Text(){ return $byUser.object.ByUserStrings.getString("手机：", "Phone Number: "); }
                static UI_user_diUserReg_cLblMail_Text(){ return $byUser.object.ByUserStrings.getString("邮箱：", "Email: "); }
                static UI_user_diUserReg_cLblSafetyCode_Text(){ return $byUser.object.ByUserStrings.getString("请输入安全码：", "Please enter the security code: "); }
                static UI_user_diUserReg_cLblSendCode_Text(){ return $byUser.object.ByUserStrings.getString("点击发送安全码", "Click here to send a security code."); }
                static UI_user_diUserReg_cBtnReg_Text(){ return $byUser.object.ByUserStrings.getString("注册", "Register"); }
                static UI_user_diUserReg_cBtnCancel_Text(){ return $byUser.object.ByUserStrings.getString("取消", "Cancel"); }
                static UI_user_dlForgetPwd_Title(){ return $byUser.object.ByUserStrings.getString("密码找回", "Password Retrieval"); }
                static UI_user_dlForgetPwd_cRdGroup_Text(){ return $byUser.object.ByUserStrings.getString("我记得", "I remember..."); }
                static UI_user_dlForgetPwd_rdUserName_Text(){ return $byUser.object.ByUserStrings.getString("用户名", "User name"); }
                static UI_user_dlForgetPwd_rdEmail_Text(){ return $byUser.object.ByUserStrings.getString("邮箱", "Email"); }
                static UI_user_dlForgetPwd_rdPhone_Text(){ return $byUser.object.ByUserStrings.getString("手机号", "Phone number"); }
                static UI_user_dlForgetPwd_cLblValue_Text(){ return $byUser.object.ByUserStrings.getString("请输入账号相关信息：", "Please enter the information related with your account: "); }
                static UI_user_dlForgetPwd_cTxtValue_placeholder(){ return $byUser.object.ByUserStrings.getString("用户名/手机号/邮箱", "User Name / Phone Number / Email"); }
                static UI_user_dlForgetPwd_cBtnSend_Text(){ return $byUser.object.ByUserStrings.getString("确认发送验证码", "Confirm to send a security code"); }
                static UI_user_dlForgetPwd_cBtnCancel_Text(){ return $byUser.object.ByUserStrings.getString("取消", "Cancel"); }
                static UI_user_RetrievePassword_Title(){ return $byUser.object.ByUserStrings.getString("重设密码找回", "Password Resetting"); }
                static UI_user_RetrievePassword_cLblSafetyCode_Text(){ return $byUser.object.ByUserStrings.getString("请输入安全码：", "Please enter the security code: "); }
                static UI_user_RetrievePassword_cLblPassword_Text(){ return $byUser.object.ByUserStrings.getString("请输入新密码：", "Please enter your new password: "); }
                static UI_user_RetrievePassword_cLblConfirmPassword_Text(){ return $byUser.object.ByUserStrings.getString("请确认密码：", "Re-enter your password: "); }
                static UI_user_RetrievePassword_cBtnSure_Text(){ return $byUser.object.ByUserStrings.getString("确认", "Confirm"); }
                static UI_user_RetrievePassword_cBtnCancel_Text(){ return $byUser.object.ByUserStrings.getString("取消", "Cancel"); }
                static UI_user_diUserLog_Title(){ return $byUser.object.ByUserStrings.getString("用户登录日志", "User Login Logs"); }
                static UI_user_modifyInfo_Title(){ return $byUser.object.ByUserStrings.getString("修改个人信息", "Modify Personal Information"); }
                static UI_user_modifyInfo_cNameLabel_Text(){ return $byUser.object.ByUserStrings.getString("请输入新名称：", "Please enter a new name: "); }
                static UI_user_modifyInfo_cSureButton_Text(){ return $byUser.object.ByUserStrings.getString("确认", "Confirm"); }
                static UI_user_modifyInfo_cCancelButton_Text(){ return $byUser.object.ByUserStrings.getString("取消", "Cancel"); }
                static UI_userICO_diUploadICO_Title(){ return $byUser.object.ByUserStrings.getString("上传用户图标", "Upload a User Icon"); }
                static UI_userICO_diUploadICO_cFilePicker_Text(){ return $byUser.object.ByUserStrings.getString("上传本地文件", "Upload local files"); }
                static UI_userICO_diUploadICO_cFilePicker_Tooltip(){ return $byUser.object.ByUserStrings.getString("上传本地文件,支持外部文件拖入", "Upload local files, support dragging external files here."); }
                static UI_userAdmin_adminManager_Title(){ return $byUser.object.ByUserStrings.getString("管理员管理", "Admin Management"); }
                static UI_userAdmin_adminManager_cBtnAdd_Text(){ return $byUser.object.ByUserStrings.getString("确认加入", "Confirm Adding"); }
                static UI_userAdmin_adminManager_cBtnDelete_Text(){ return $byUser.object.ByUserStrings.getString("确认删除", "Confirm Deleting"); }
                static UI_userAdmin_adminManager_columnUserID_Text(){ return $byUser.object.ByUserStrings.getString(" 用户ID", " User ID"); }
                static UI_userAdmin_adminManager_columnUserName_Text(){ return $byUser.object.ByUserStrings.getString(" 用户名", " User name"); }
                static UI_userAdmin_adminManager_columnUserDisplayName_Text(){ return $byUser.object.ByUserStrings.getString(" 用户显示名", " User display name"); }
                static UI_userAdmin_adminManager_columnUserPhone_Text(){ return $byUser.object.ByUserStrings.getString(" 用户手机", " User Phone number"); }
                static UI_userAdmin_adminManager_menuitem_AddUser_Text(){ return $byUser.object.ByUserStrings.getString("增加管理员", "Add User"); }
                static UI_userAdmin_adminManager_menuitem_DeleteUser_Text(){ return $byUser.object.ByUserStrings.getString("删除管理员", "Delete User"); }
                static UI_user_popupUser_Title(){ return $byUser.object.ByUserStrings.getString("弹窗选择用户", "Users Selection Popup"); }
                static UI_user_popupUser_cLblKeyword_Text(){ return $byUser.object.ByUserStrings.getString("搜索", "Search"); }
                static UI_user_popupUser_cTxtKeyword_Placeholder(){ return $byUser.object.ByUserStrings.getString("用户名、手机、邮箱", "User Name / Phone Number / Email"); }
                static UI_user_popupUser_cBtnSearch_Text(){ return $byUser.object.ByUserStrings.getString("查询", "Query"); }
                static UI_user_popupUser_cBtnOk_Text(){ return $byUser.object.ByUserStrings.getString("确认加入", "Confirm"); }
            },
            transmit: [ ],
            static: { props: { language: Byt.String } }
        }
    },
    identity: {
        userUpload: {
            type: class userUpload extends Byt.Identity { },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iFileName", "iFileSize", "iSummery", "iUserID", "iDT", "rUser" ] }
        },
        user: {
            type: class user extends Byt.Identity {
                $0(){
                    super.$0();
                    this.pRegMobile = "^[\\d]{11}$";
                    this.pRegMaile = "^[_\\-0-9a-z]+@(([_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6})|([_\\-0-9a-z]{1,32}\\.[_\\-0-9a-z]{1,32}\\.[0-9a-z]{2,6}))$";
                    this.pRegSafetyCode = "^[0-9]{4,8}$";
                    this.pConfigSMSCode = false;
                    this.regPwd = "^[a-zA-Z0-9_@#$]{6,32}$";
                    this.regUserName = "^[0-9a-zA-Z@_#\\.\\-]{2,32}$";
                    this.pVerifyMode = "cookie";
                }
                userLoginChild(f_resultValue, f_user, f_pwd){
                    f_resultValue.info = this.verifyUserFormat(f_user);
                    if(f_resultValue.info != null){ return false; }
                    f_resultValue.info = this.verifyPwd(f_pwd);
                    if(f_resultValue.info != null){ return false; }
                    return true;
                }
                async userLogin(f_user, f_pwd){
                    let tmpResultValue = new $byUser.object.resultUser().$init($ => $.$0());
                    
                    {
                        if(!this.userLoginChild(tmpResultValue, f_user, f_pwd)){ return tmpResultValue; }
                        tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 1, target: this, args: [ await this.rsaEncode(f_user), await this.rsaEncode(f_pwd) ], argTypes: [ Byt.String, Byt.String ], return: "byUser.object.resultUser" });
                        if(tmpResultValue.isOk){
                            tmpResultValue.loginRow.a.i$assign("iName", await this.rsaDecode(tmpResultValue.loginRow.a.i$access("iName")));
                            tmpResultValue.loginRow.a.i$assign("iDisplayName", await this.rsaDecode(tmpResultValue.loginRow.a.i$access("iDisplayName")));
                            this.pSession = tmpResultValue.loginRow;
                            $by.object.System.byCookie = tmpResultValue.loginRow.a.i$access("iID");
                            if(!this.loginSuccessEvent.by$equals(null)){ await this.loginSuccessEvent.$invoke(tmpResultValue.loginRow); }
                        }
                        return tmpResultValue;
                    }
                }
                async confirmUserIsLogin(){ return await this.confirmUserIsLogin$1("verifyLogin"); }
                async confirmUserIsLogin$1(f_verifyMode){
                    
                    {
                        if(this.pVerifyMode == "cookie"){
                            if($by.object.System.byCookie == null || $by.object.System.byCookie == ""){
                                if(f_verifyMode == "verifyLogin"){
                                    let tmpWaitingDialog = await $byCommon.identity.relatedDialog.Loading();
                                    await (await $byUser.dialog.user$diLogin.$new(this, $ => $.$0())).showDialog();
                                    tmpWaitingDialog.close();
                                }
                            }
                            return $by.object.System.byCookie == null || $by.object.System.byCookie == "" ? false : true;
                        }
                        else {
                            if(this.pSession == null || this.pSession.a.i$access("iID") == null || this.pSession.a.i$access("iID") == ""){
                                if(f_verifyMode == "verifyLogin"){
                                    let tmpWaitingDialog = await $byCommon.identity.relatedDialog.Loading();
                                    await (await $byUser.dialog.user$diLogin.$new(this, $ => $.$0())).showDialog();
                                    tmpWaitingDialog.close();
                                }
                            }
                            return this.pSession == null || this.pSession.a.i$access("iID") == null || this.pSession.a.i$access("iID") == "" ? false : true;
                        }
                    }
                }
                confirmUserIsLogin$2(f_userID){
                    
                    {
                        if(this.pVerifyMode == "cookie"){
                            if($by.object.System.byCookie == null || $by.object.System.byCookie == "")
                                return false;
                            else 
                                return $by.object.System.byCookie == f_userID ? true : false;
                        }
                        else 
                            return this.pSession == null || this.pSession.a.i$access("iID") == null || this.pSession.a.i$access("iID") == "" ? false : true;
                    }
                }
                addUserMenuBar(f_menu){
                    if(this.pSession != null){
                        let tmpMenuList = this.getUserMenuItem();
                        let tmpUserRoot = new $by.object.MenuItem().$init($ => {
                            $.name = "user";
                            $.text = $byUser.object.ByUserStrings.UI_MenuItem_User();
                        });
                        {
                            if(this.pSession.iFileName == null || this.pSession.iFileName == ""){ tmpUserRoot.image = $by.object.Ku.getKu("byUser").getResource("byUser.png").toImage(); }
                            else { tmpUserRoot.image = $by.object.Image.fromUrl(this.rUserICO.getIcoUrlPath(Byt.String(this.pSession.iFileName) + "." + Byt.String(this.pSession.iExtendName))); }
                        }
                        f_menu.add(tmpUserRoot);
                        for (let item of tmpMenuList){ tmpUserRoot.add(item); }
                        this.rUserICO.userICOChangeEvent.$add(f_userRow => {
                            {
                                if(this.pSession.iFileName == null || this.pSession.iFileName == ""){ tmpUserRoot.image = $by.object.Ku.getKu("byUser").getResource("byUser.png").toImage(); }
                                else { tmpUserRoot.image = $by.object.Image.fromUrl(this.rUserICO.getIcoUrlPath(Byt.String(this.pSession.iFileName) + "." + Byt.String(this.pSession.iExtendName))); }
                            }
                        });
                        return tmpUserRoot;
                    }
                    return null;
                }
                modifyUserRoot(f_userItem){
                    if(this.pSession != null){
                        let tmpMenuList = this.getUserMenuItem();
                        let tmpIco = this.pSession.iFileName == null || this.pSession.iFileName == "" ? "byUser.png" : Byt.String(this.pSession.iFileName) + "." + Byt.String(this.pSession.iExtendName);
                        {
                            let tmpUrl = this.rUserICO.getIcoUrlPath(tmpIco);
                            f_userItem.image = $by.object.Image.fromUrl(tmpUrl);
                        }
                        f_userItem.clear();
                        for (let item of tmpMenuList){ f_userItem.add(item); }
                    }
                    this.rUserICO.userICOChangeEvent.$add(f_userRow => {
                        {
                            let tmpUrl = this.rUserICO.getIcoUrlPath(Byt.String(this.pSession.iFileName) + "." + Byt.String(this.pSession.iExtendName));
                            f_userItem.image = $by.object.Image.fromUrl(tmpUrl);
                        }
                    });
                }
                getUserMenuItem(){
                    let tmpResultList = new $by.object.List();
                    let tmpRegStripItem = new $by.object.MenuItem().$init($ => {
                        $.name = "reg";
                        $.text = $byUser.object.ByUserStrings.UI_MenuItem_RegisterUser();
                        $.image = $by.object.Ku.getKu("byUser").getResource("reg.png").toImage();
                    });
                    tmpRegStripItem.click.$add(async (sender, args) => {
                        let tmpRegDialog = await $byUser.dialog.user$diUserReg.$new(this, $ => $.$0());
                        tmpRegDialog.height = 500;
                        tmpRegDialog.regSuccess.$add(async f_userRegRow => {
                            let tmpLogin = await $byUser.dialog.user$diLogin.$new(this, $ => $.$0());
                            tmpLogin.cTxtName.text = f_userRegRow.i$access("iName");
                            tmpLogin.cTxtPwd.text = f_userRegRow.i$access("iPassword");
                            tmpLogin.show();
                            await tmpLogin.startLogin(null, null);
                        });
                        await tmpRegDialog.showDialog();
                    });
                    tmpResultList.add(tmpRegStripItem);
                    let tmpLoginStripItem = new $by.object.MenuItem().$init($ => {
                        $.text = $byUser.object.ByUserStrings.UI_MenuItem_Login();
                        $.image = $by.object.Ku.getKu("byUser").getResource("login.png").toImage();
                    });
                    tmpLoginStripItem.click.$add(async (sender, args) => {
                        let tmpLogin = await $byUser.dialog.user$diLogin.$new(this, $ => $.$0());
                        await tmpLogin.showDialog();
                    });
                    tmpResultList.add(tmpLoginStripItem);
                    let tmpModifPwdStripItem = new $by.object.MenuItem().$init($ => {
                        $.text = $byUser.object.ByUserStrings.UI_MenuItem_ChangePassword();
                        $.image = $by.object.Ku.getKu("byUser").getResource("pwdModif.png").toImage();
                    });
                    tmpModifPwdStripItem.click.$add(async (sender, args) => {
                        let tmpLoginDialog = await $byUser.dialog.user$diModifPwd.$new(this, $ => $.$0());
                        await tmpLoginDialog.showDialog();
                    });
                    tmpResultList.add(tmpModifPwdStripItem);
                    {
                        let tmpDiUploadICOItem = new $by.object.MenuItem().$init($ => {
                            $.text = $byUser.object.ByUserStrings.UI_MenuItem_UploadIcon();
                            $.image = $by.object.Ku.getKu("byUser").getResource("byUser.png").toImage();
                        });
                        tmpDiUploadICOItem.click.$add(async (sender, args) => {
                            let tmpDiUploadICODialog = await $byUser.dialog.userICO$diUploadICO.$new(this.rUserICO, $ => $.$0());
                            await tmpDiUploadICODialog.showDialog();
                        });
                        tmpResultList.add(tmpDiUploadICOItem);
                        if(this.rUserAdmin.isAdmin()){
                            let tmpAdminMenu = new $by.object.MenuItem().$init($ => {
                                $.text = $byUser.object.ByUserStrings.UI_MenuItem_Admin();
                                $.image = $by.object.Ku.getKu("byUser").getResource("user.png").toImage();
                            });
                            tmpAdminMenu.click.$add(async (sender, args) => {
                                let tmpAdminDialog = await $byUser.dialog.userAdmin$adminManager.$new(this.rUserAdmin, $ => $.$0());
                                await tmpAdminDialog.showDialog();
                            });
                            tmpResultList.add(tmpAdminMenu);
                        }
                    }
                    let tmpExitStripItem = new $by.object.MenuItem().$init($ => {
                        $.text = $byUser.object.ByUserStrings.UI_MenuItem_Exit();
                        $.image = $by.object.Ku.getKu("byUser").getResource("exit.png").toImage();
                    });
                    tmpExitStripItem.click.$add(async (sender, args) => { await this.exit(); });
                    tmpResultList.add(tmpExitStripItem);
                    return tmpResultList;
                }
                async exit(){
                    
                    {
                        $by.object.System.byCookie = null;
                        await $byUser.$remote({ kind: "SKILL", NO: 8, target: this });
                        this.pSession = null;
                        if(!this.userExitEvent.by$equals(null)){ await this.userExitEvent.$invoke(this.pSession); }
                    }
                }
                async userReg(f_userRow, f_SafetyCode){
                    
                    {
                        f_userRow.i$assign("iDisplayName", await this.rsaEncode(f_userRow.i$access("iDisplayName")));
                        f_userRow.i$assign("iMail", await this.rsaEncode(f_userRow.i$access("iMail")));
                        f_userRow.i$assign("iMobile", await this.rsaEncode(f_userRow.i$access("iMobile")));
                        f_userRow.i$assign("iName", await this.rsaEncode(f_userRow.i$access("iName")));
                        return await $byUser.$remote({ kind: "SKILL", NO: 9, target: this, args: [ f_userRow, await this.rsaEncode(f_SafetyCode) ], argTypes: [ Byt.Row, Byt.String ], return: $by.object.Result });
                    }
                }
                async userPwdModif(f_sourcePwd, f_newPwd, f_ID){
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 11, target: this, args: [ await this.rsaEncode(f_sourcePwd), await this.rsaEncode(f_newPwd), await this.rsaEncode(f_ID) ], argTypes: [ Byt.String, Byt.String, Byt.String ], return: $by.object.Result }); }
                }
                async userPwdModif$1(f_userMailMobile, f_safetyCodeMode, f_newPwd, f_safetyCode){
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 12, target: this, args: [ await this.rsaEncode(f_userMailMobile), f_safetyCodeMode, await this.rsaEncode(f_newPwd), await this.rsaEncode(f_safetyCode) ], argTypes: [ Byt.String, "byUser.enum.safetyCodeMode", Byt.String, Byt.String ], return: $by.object.Result }); }
                }
                verifyMobileFormat(f_mobile){
                    if(!f_mobile.by$isMatch(this.pRegMobile, "multiIgnoreCase")){ return $byUser.object.ByUserStrings.Info_Phone_Must_11_Digits(); }
                    return null;
                }
                async verifyMobileExists(f_mobile){
                    
                    if(this.verifyMobileFormat(f_mobile) != null){ return false; }
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 14, target: this, args: [ await this.rsaEncode(f_mobile) ], argTypes: [ Byt.String ], return: Byt.Bool }); }
                }
                async verifyRegMail(f_mail){
                    
                    let tmpFormat = this.verifyMailFormat(f_mail);
                    if(tmpFormat != null){ return tmpFormat; }
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 15, target: this, args: [ await this.rsaEncode(f_mail) ], argTypes: [ Byt.String ], return: Byt.String }); }
                    return null;
                }
                verifyMailFormat(f_mail){
                    if(f_mail.length > 64 || f_mail.length < 6){ return $byUser.object.ByUserStrings.Info_Email_Too_Long_Or_Too_Short(); }
                    if(!f_mail.by$isMatch(this.pRegMaile, "multiIgnoreCase")){ return $byUser.object.ByUserStrings.Info_Email_Format_Invalid(); }
                    return null;
                }
                async verifyMailExists(f_mail){
                    
                    let tmpResulValue = new $by.object.Result();
                    tmpResulValue.info = this.verifyMailFormat(f_mail);
                    if(tmpResulValue.info != null){ return tmpResulValue; }
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 17, target: this, args: [ await this.rsaEncode(f_mail) ], argTypes: [ Byt.String ], return: $by.object.Result }); }
                }
                verifySafetyCodeFormat(f_SafetyCode){ return f_SafetyCode.by$isMatch("^[\\d]{4,8}$", "multiline"); }
                verifyCookies(f_cookie){
                    let tmpResultValue = new $by.object.Result();
                    if(!f_cookie.by$isMatch("^[0-9a-z]{2,32}$", "multiIgnoreCase")){
                        tmpResultValue.info = $byUser.object.ByUserStrings.Info_Cookie_Invalid(f_cookie);
                        return tmpResultValue;
                    }
                    tmpResultValue.isOk = true;
                    return tmpResultValue;
                }
                async postSafetyReg(f_mail, f_mobile){
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 25, target: this, args: [ await this.rsaEncode(f_mail), await this.rsaEncode(f_mobile) ], argTypes: [ Byt.String, Byt.String ], return: $by.object.Result }); }
                }
                async getAnonymousUser(){
                    let tmpResultValue = new $byUser.object.resultUser().$init($ => $.$0());
                    
                    {
                        tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 28, target: this, return: "byUser.object.resultUser" });
                        if(tmpResultValue.isOk){
                            if(tmpResultValue.loginRow != null){
                                tmpResultValue.loginRow.a.i$assign("iName", await this.rsaDecode(tmpResultValue.loginRow.a.i$access("iName")));
                                tmpResultValue.loginRow.a.i$assign("iDisplayName", await this.rsaDecode(tmpResultValue.loginRow.a.i$access("iDisplayName")));
                                $by.object.System.byCookie = tmpResultValue.loginRow.a.i$access("iID");
                            }
                            if(!this.loginSuccessEvent.by$equals(null)){ await this.loginSuccessEvent.$invoke(tmpResultValue.loginRow); }
                        }
                    }
                    return tmpResultValue;
                }
                getSessionUserRow(){
                    
                    return this.pSession;
                }
                async autoLoginFromCookie(){
                    if(this.pSession == null && $by.object.System.byCookie != null && $by.object.System.byCookie != "")
                        this.pSession = await $byUser.$remote({ kind: "SKILL", NO: 30, target: this, return: "byUser.orm.user$userOrm" });
                }
                async init(){ await this.generateRsaKey(); }
                async generateRsaKey(){
                    if(this.publicKey == null || this.publicKey == ""){
                        let tmpKey = await $byExternal.object.security.rsaCreatePublicKeyAndPrivateKey();
                        this.publicKey = tmpKey[0];
                        this.privateKey = tmpKey[1];
                    }
                    
                    {
                        if(this.publicKeyServer == null || this.publicKeyServer == ""){ this.publicKeyServer = await $byUser.$remote({ kind: "SKILL", NO: 34, target: this, return: Byt.String }); }
                        let tmpRegPublic = await $byUser.$remote({ kind: "SKILL", NO: 35, target: this, args: [ this.publicKey ], argTypes: [ Byt.String ], return: Byt.Bool });
                        if(!tmpRegPublic){ await $by.object.Message.alert($byUser.object.ByUserStrings.Info_RSA_Public_Key_Register_Failed()); }
                    }
                }
                async rsaEncode(f_encede){
                    if(f_encede == null || f_encede == "" || f_encede.length > 245){ return f_encede; }
                    
                    {
                        if(this.publicKeyServer != null && this.publicKeyServer != ""){ return await $byExternal.object.security.rsaEncrypt(f_encede, this.publicKeyServer); }
                    }
                    return f_encede;
                }
                async rsaDecode(f_decode){
                    if(f_decode == null || f_decode.length != 344){ return f_decode; }
                    return await $byExternal.object.security.rsaDecrypt(f_decode, this.privateKey);
                }
                async md5Plus(f_sourcePwd){
                    let tmpSb = new $by.object.StringBuilder();
                    for (let i = 0; i < f_sourcePwd.length; i++){
                        tmpSb.append($by.object.Int.toString(Byt.Char(f_sourcePwd[i]).valueOf(), 2));
                        tmpSb.append(Byt.Char(f_sourcePwd[((((f_sourcePwd.length - i) | 0) - 1) | 0)]));
                        tmpSb.append($by.object.Int.toString(Byt.Char(f_sourcePwd[i]).valueOf(), 16));
                    }
                    return await $byExternal.object.security.md5(tmpSb.by$toString());
                }
                verifyPwd(f_pwd){
                    if(!f_pwd.by$isMatch(this.regPwd, "multiIgnoreCase")){ return $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(); }
                    return null;
                }
                verifyUserFormat(f_user){
                    if(f_user.length < 2 || f_user.length > 32){ return $byUser.object.ByUserStrings.Info_UserName_Length_Invalid(); }
                    if(!f_user.by$isMatch(this.regUserName, "multiIgnoreCase")){ return $byUser.object.ByUserStrings.Info_UserName_Pattern_Invalid(); }
                    return null;
                }
                async verifyRegisterUser(f_user){
                    
                    let tmpUserFormat = this.verifyUserFormat(f_user);
                    if(tmpUserFormat != null){ return tmpUserFormat; }
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 41, target: this, args: [ await this.rsaEncode(f_user) ], argTypes: [ Byt.String ], return: Byt.String }); }
                }
                async userExists(f_user){
                    
                    if(this.verifyUserFormat(f_user) != null){ return false; }
                    
                    { return await $byUser.$remote({ kind: "SKILL", NO: 42, target: this, args: [ await this.rsaEncode(f_user) ], argTypes: [ Byt.String ], return: Byt.Bool }); }
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iFreeze", "iRank", "iName", "iPassword", "iDisplayName", "iMobile", "iMail", "iCerMode", "iCerName", "iCerNO", "iMoney", "iRemark", "iRegDt", "rUserICO", "rUserUpload", "rLog", "rUserAdmin", "rAnonymous" ], props: { pSession: "byUser.orm.user$userOrm", pRegMobile: Byt.String, pRegMaile: Byt.String, pRegSafetyCode: Byt.String, pConfigSMSCode: Byt.Bool, publicKey: Byt.String, privateKey: Byt.String, publicKeyServer: Byt.String, regPwd: Byt.String, regUserName: Byt.String, pVerifyMode: "byUser.enum.verifyMode" }, events: [ "loginSuccessEvent", "userExitEvent" ] }
        },
        userICO: {
            type: class userICO extends Byt.Identity {
                $0(){
                    super.$0();
                    this.pAllowUploadFileType = ",txt,jpg,png,ico,sql,by,mp4,zip,rar,";
                    this.pUploadFileSize = 2097152;
                    this.pUploadUserICOFileSize = 50000;
                }
                getAcceptType(){ return this.pAllowUploadFileType.by$replace(",", ",.").by$replaceReg("(^\\,)|(\\.\\,$)", "", "none"); }
                getIcoUrlPath(f_pathICO){
                    let tmpServerPath = null;
                    
                    { tmpServerPath = $by.object.System.serverURL; }
                    return Byt.String(tmpServerPath.by$replaceReg("[^/]+$", "", "none")) + Byt.String("userIco".by$toString()) + "/" + Byt.String(f_pathICO.by$replaceReg("[\\\\]+", "/", "none"));
                }
                async fileUpload(f_fileBytes, f_dirMode, f_extendName){
                    if(f_extendName == null || this.pAllowUploadFileType.by$indexOf("," + Byt.String(f_extendName.by$toLower()) + ",") == -1)
                        return new $by.object.Result().$init($ => { $.info = $byUser.object.ByUserStrings.Info_Upload_Format_Unsupported(this.pAllowUploadFileType.by$replaceReg("(^,)|(,$)", "", "none")); });
                    if(f_dirMode == "userIco"){
                        if(f_fileBytes.length > this.pUploadUserICOFileSize)
                            return new $by.object.Result().$init($ => { $.info = $byUser.object.ByUserStrings.Info_Upload_File_To_Large(((this.pUploadUserICOFileSize / 1024) | 0)); });
                    }
                    else if(f_dirMode == "contentOther"){
                        if(f_fileBytes.length > this.pUploadFileSize)
                            return new $by.object.Result().$init($ => { $.info = $byUser.object.ByUserStrings.Info_Upload_File_To_Large(((this.pUploadFileSize / 1024) | 0)); });
                        
                    }
                    
                    {
                        let tmpResult = await $byUser.$remote({ kind: "SKILL", NO: 47, target: this, args: [ f_fileBytes, f_dirMode, f_extendName ], argTypes: [ [ Byt.Array, Byt.Byte ], "byUser.enum.uploadMode", Byt.String ], return: $by.object.Result });
                        if(tmpResult.isOk && f_dirMode == "userIco"){
                            let icoRelativePath = tmpResult.info;
                            let strings = icoRelativePath.by$split(Byt.Char("\\"));
                            this.rUser.pSession.userIcoPath = strings[0];
                            let strings2 = strings[1].by$split(Byt.Char("."));
                            this.rUser.pSession.iFileName = strings2[0];
                            this.rUser.pSession.iExtendName = strings2[1];
                            if(!this.userICOChangeEvent.by$equals(null)){ await this.userICOChangeEvent.$invoke(this.rUser.pSession); }
                        }
                        return tmpResult;
                    }
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iIcoFile", "iFileName", "iExtendName", "iUploadDt", "rUser" ], props: { pAllowUploadFileType: Byt.String, pUploadFileSize: Byt.Int, pUploadUserICOFileSize: Byt.Int }, events: [ "userICOChangeEvent" ] }
        },
        anonymous: {
            type: class anonymous extends Byt.Identity { },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iUserID", "iRegDt", "iIP" ] }
        },
        userAdmin: {
            type: class userAdmin extends Byt.Identity {
                isAdmin(){
                    
                    {
                        if(this.rUser.pSession != null && this.rUser.pSession.a.i$access("iID") != null){ return this.rUser.pSession.b.i$access("iID") != null && this.rUser.pSession.b.i$access("iID") != "" && this.rUser.pSession.a.i$access("iID") == this.rUser.pSession.b.i$access("iID") ? true : false; }
                        return false;
                    }
                }
                async getAdmin(){
                    if(!this.isAdmin())
                        return null;
                    
                    {
                        let tmpList = await $byUser.$remote({ kind: "SKILL", NO: 50, target: this, return: [ "by.object.List", "byUser.orm.userAdmin$adminOrm" ] });
                        if(tmpList == null)
                            return null;
                        for (let item of tmpList){
                            item.a.i$assign("iID", await this.rUser.rsaDecode(item.a.i$access("iID")));
                            item.iDisplayName = await this.rUser.rsaDecode(item.iDisplayName);
                            item.iMobile = await this.rUser.rsaDecode(item.iMobile);
                            item.iName = await this.rUser.rsaDecode(item.iMobile);
                        }
                        return tmpList;
                    }
                }
                async adminAddRemove(f_adminRow, f_action){
                    if(f_action != "delete" && f_action != "insert")
                        return new $by.object.Result().$init($ => { $.info = $byUser.object.ByUserStrings.Info_Operation_Limited(); });
                    if(!this.isAdmin())
                        return new $by.object.Result().$init($ => { $.info = $byUser.object.ByUserStrings.Info_Operation_Forbidden_Must_Be_Admin(); });
                    
                    {
                        f_adminRow.i$assign("iID", await this.rUser.rsaEncode(f_adminRow.i$access("iID")));
                        let tmpList = await $byUser.$remote({ kind: "SKILL", NO: 51, target: this, args: [ f_adminRow, f_action ], argTypes: [ Byt.Row, $by.enum.Action ], return: $by.object.Result });
                        return tmpList;
                    }
                }
                async getPopupUser(f_keyword){
                    if(!this.isAdmin())
                        return null;
                    
                    {
                        let tmpList = await $byUser.$remote({ kind: "SKILL", NO: 52, target: this, args: [ f_keyword ], argTypes: [ Byt.String ], return: [ "by.object.List", Byt.Row ] });
                        if(tmpList == null)
                            return null;
                        for (let item of tmpList){
                            item.i$assign("iID", await this.rUser.rsaDecode(item.i$access("iID")));
                            item.i$assign("iName", await this.rUser.rsaDecode(item.i$access("iName")));
                            item.i$assign("iDisplayName", await this.rUser.rsaDecode(item.i$access("iDisplayName")));
                            item.i$assign("iMobile", await this.rUser.rsaDecode(item.i$access("iMobile")));
                            item.i$assign("iMail", await this.rUser.rsaDecode(item.i$access("iMail")));
                        }
                        return tmpList;
                    }
                }
                async isFirstRun(){
                    
                    return await $byUser.$remote({ kind: "SKILL", NO: 53, target: this, return: Byt.Bool });
                }
            },
            base: { inherit: $by.identity.Table },
            instance: { components: [ "iID", "iUserMode", "iDt", "rUser" ] }
        }
    },
    dialog: {
        user$diLogin: {
            type: class diLogin extends Byt.Dialog {
                async $0(){
                    this.cTxtName.$init($ => { $.placeholder = ""; });
                    this.cTxtPwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cLblFindPwd.$init($ => {
                        $.cursor = "hand";
                        $.foreColor = new $by.object.Color(191, 22, 22);
                    });
                    {
                        this.width = 450;
                        this.height = 320;
                        this.cLblName.top = 0;
                        this.cLblName.left = 80;
                        this.cTxtName.top = 40;
                        this.cTxtName.left = 80;
                        this.cLblPwd.top = 80;
                        this.cLblPwd.left = 80;
                        this.cTxtPwd.top = 120;
                        this.cTxtPwd.left = 80;
                        this.cBtnLogin.left = 120;
                        this.cBtnLogin.top = 180;
                        this.cBtnReg.left = 220;
                        this.cBtnReg.top = 180;
                        this.cLblFindPwd.left = 80;
                        this.cLblFindPwd.top = 215;
                        this.cLblName.element.addClass("by-user-nameLabel");
                        this.cTxtName.element.addClass("by-user-nameTextBox");
                        this.cLblPwd.element.addClass("by-user-passwordLabel");
                        this.cTxtPwd.element.addClass("by-user-passwordTextBox");
                        this.cBtnLogin.element.addClass("by-user-loginButton");
                        this.cBtnReg.element.addClass("by-user-registButton");
                        this.cLblFindPwd.element.addClass("by-user-findPasswordLabel");
                    }
                    let tmpInitAllow = [ this.cBtnLogin, this.cBtnReg, this.cTxtName, this.cTxtPwd ];
                    await this.$identity().init();
                    this.cBtnLogin.click.$add(this.$access("startLogin"));
                    this.cBtnReg.click.$add(this.$access("startReg"));
                    this.cLblFindPwd.click.$add(this.$access("startFindPwd"));
                    this.cTxtPwd.keyUp.$add(async (sender, keyEventArgs) => {
                        $by.object.System.currentWindow.log(keyEventArgs.keyCode);
                        if(keyEventArgs.keyCode == "Enter"){
                            this.isEnabled = false;
                            await this.startLogin(null, null);
                            this.isEnabled = true;
                        }
                    });
                    this.initUI();
                    if(await this.$identity().rUserAdmin.isFirstRun()){
                        this.cTxtName.text = "admin";
                        this.cTxtPwd.isPassword = false;
                        this.cTxtPwd.text = "admin123";
                        await $by.object.Message.alert("请记住初始管理员用户名与密码，密码可以在管理界面修改，密码框明文仅显示一次！");
                    }
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_diLogin_Title();
                    this.cLblName.text = $byUser.object.ByUserStrings.UI_user_diLogin_cLblName_Text();
                    this.cLblPwd.text = $byUser.object.ByUserStrings.UI_user_diLogin_cLblPwd_Text();
                    this.cBtnLogin.text = $byUser.object.ByUserStrings.UI_user_diLogin_cBtnLogin_Text();
                    this.cBtnReg.text = $byUser.object.ByUserStrings.UI_user_diLogin_cBtnReg_Text();
                    this.cLblFindPwd.text = $byUser.object.ByUserStrings.UI_user_diLogin_cLblFindPwd_Text();
                }
                async startFindPwd(sender, args){
                    let tmpDlForgetPwd = await $byUser.dialog.user$dlForgetPwd.$new(this.$identity(), $ => $.$0());
                    await tmpDlForgetPwd.showDialog();
                }
                async startReg(sender, args){
                    let tmpUserRegDialog = await $byUser.dialog.user$diUserReg.$new(this.$identity(), $ => $.$0());
                    await tmpUserRegDialog.showDialog();
                }
                async startLogin(f_sender, f_e){
                    this.cBtnLogin.isEnabled = false;
                    let tmpUser = this.cTxtName.text.trim();
                    let tmpUserVerify = this.$identity().verifyUserFormat(tmpUser);
                    if(tmpUserVerify != null){
                        await $by.object.Message.alert(tmpUserVerify);
                        this.cBtnLogin.isEnabled = true;
                        return;
                    }
                    let tmpPwd = this.cTxtPwd.text.trim();
                    let tmpPwdVerify = this.$identity().verifyPwd(tmpPwd);
                    if(tmpPwdVerify != null){
                        await $by.object.Message.alert(tmpPwdVerify);
                        this.cBtnLogin.isEnabled = true;
                        return;
                    }
                    tmpPwd = await this.$identity().md5Plus(tmpPwd);
                    let tmpResultValue = await this.$identity().userLogin(tmpUser, tmpPwd);
                    if(tmpResultValue.isOk){ this.close(); }
                    else { await $by.object.Message.alert(Byt.String($byUser.object.ByUserStrings.Info_Login_Failed()) + Byt.String(tmpResultValue.info)); }
                    this.cBtnLogin.isEnabled = true;
                }
            },
            dialog: { props: { cLblName: $by.object.Label, cTxtName: $by.object.TextBox, cLblPwd: $by.object.Label, cTxtPwd: $by.object.TextBox, cBtnLogin: $by.object.Button, cBtnReg: $by.object.Button, cLblFindPwd: $by.object.Label } }
        },
        user$diModifPwd: {
            type: class diModifPwd extends Byt.Dialog {
                $0(){
                    this.cTxtSourcePwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cTxtNewPwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cTxtConfirmNewPwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.pVerifyTextbox = new $byCommon.object.verifyTextbox().$init($ => $.$0());
                    {
                        this.width = 450;
                        this.height = 350;
                        this.cLblSourcePwd.top = 0;
                        this.cLblSourcePwd.left = 80;
                        this.cTxtSourcePwd.top = 40;
                        this.cTxtSourcePwd.left = 80;
                        this.cLblNewPwd.top = 80;
                        this.cLblNewPwd.left = 80;
                        this.cTxtNewPwd.top = 120;
                        this.cTxtNewPwd.left = 80;
                        this.cLblConfirmNewPwd.top = 160;
                        this.cLblConfirmNewPwd.left = 80;
                        this.cTxtConfirmNewPwd.top = 200;
                        this.cTxtConfirmNewPwd.left = 80;
                        this.cBtnSure.left = 120;
                        this.cBtnSure.top = 260;
                        this.cBtnCancel.left = 220;
                        this.cBtnCancel.top = 260;
                    }
                    this.pVerifyTextbox.add(this.cLblNewPwd, this.cTxtNewPwd, false, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.pVerifyTextbox.add(this.cLblSourcePwd, this.cTxtSourcePwd, false, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.cBtnSure.click.$add(this.$access("btnSure_click"));
                    this.cBtnCancel.click.$add(this.$access("btnCancel_click"));
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_Title();
                    this.cLblSourcePwd.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_cLblSourcePwd_Text();
                    this.cLblNewPwd.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_cLblNewPwd_Text();
                    this.cLblConfirmNewPwd.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_cLblConfirmNewPwd_Text();
                    this.cBtnSure.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_cBtnSure_Text();
                    this.cBtnCancel.text = $byUser.object.ByUserStrings.UI_user_diModifPwd_cBtnCancel_Text();
                }
                btnCancel_click(sender, args){ this.close(); }
                async btnSure_click(sender, args){
                    let tmpSourcePwd = this.cTxtSourcePwd.text.trim();
                    let tmpNewPwd = this.cTxtNewPwd.text.trim();
                    let confirmPwd = this.cTxtConfirmNewPwd.text.trim();
                    if(!this.pVerifyTextbox.verify()){ return; }
                    if(tmpNewPwd != confirmPwd){
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Entered_Passwords_Not_Match());
                        return;
                    }
                    let tmpResultValue = await this.$identity().userPwdModif(await this.$identity().md5Plus(tmpSourcePwd), await this.$identity().md5Plus(tmpNewPwd), this.$identity().pSession.a.i$access("iID"));
                    if(tmpResultValue.isOk){
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Modify_Completed());
                        this.close();
                    }
                    else { await $by.object.Message.alert(Byt.String($byUser.object.ByUserStrings.Info_Modify_Failed()) + Byt.String(tmpResultValue.info)); }
                }
            },
            instance: { props: { pVerifyTextbox: "byCommon.object.verifyTextbox" } },
            dialog: { props: { cLblSourcePwd: $by.object.Label, cTxtSourcePwd: $by.object.TextBox, cLblNewPwd: $by.object.Label, cTxtNewPwd: $by.object.TextBox, cLblConfirmNewPwd: $by.object.Label, cTxtConfirmNewPwd: $by.object.TextBox, cBtnSure: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        user$diUserReg: {
            type: class diUserReg extends Byt.Dialog {
                $0(){
                    this.cTxtName.$init($ => { $.placeholder = ""; });
                    this.cTxtPwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cTxtConfirmPwd.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cTxtMobile.$init($ => { $.placeholder = ""; });
                    this.cTxtMail.$init($ => { $.placeholder = ""; });
                    this.cLblSafetyCode.$init($ => { $.visible = false; });
                    this.cTxtSafetyCode.$init($ => {
                        $.visible = false;
                        $.placeholder = "";
                    });
                    this.cLblSendCode.$init($ => {
                        $.cursor = "hand";
                        $.foreColor = new $by.object.Color(191, 22, 22);
                    });
                    this.pUserRow = new $by.object.Row().$bindIdentity(this.$identity());
                    this.pUserRsaRow = new $by.object.Row().$bindIdentity(this.$identity());
                    this.pVerifyTextbox = new $byCommon.object.verifyTextbox().$init($ => $.$0());
                    {
                        this.width = 450;
                        this.height = 650;
                        this.cLblName.top = 0;
                        this.cLblName.left = 80;
                        this.cTxtName.top = 40;
                        this.cTxtName.left = 80;
                        this.cLblPwd.top = 80;
                        this.cLblPwd.left = 80;
                        this.cTxtPwd.top = 120;
                        this.cTxtPwd.left = 80;
                        this.cLblConfirmPwd.top = 160;
                        this.cLblConfirmPwd.left = 80;
                        this.cTxtConfirmPwd.top = 200;
                        this.cTxtConfirmPwd.left = 80;
                        this.cLblMobile.top = 240;
                        this.cLblMobile.left = 80;
                        this.cTxtMobile.top = 280;
                        this.cTxtMobile.left = 80;
                        this.cLblMail.top = 320;
                        this.cLblMail.left = 80;
                        this.cTxtMail.top = 360;
                        this.cTxtMail.left = 80;
                        this.cLblSafetyCode.top = 400;
                        this.cLblSafetyCode.left = 80;
                        this.cTxtSafetyCode.top = 440;
                        this.cTxtSafetyCode.left = 80;
                        this.cLblSendCode.top = 468;
                        this.cLblSendCode.left = 80;
                        this.cBtnReg.left = 120;
                        this.cBtnReg.top = 528;
                        this.cBtnCancel.left = 220;
                        this.cBtnCancel.top = 528;
                    }
                    if(this.$identity().pConfigSMSCode){ this.cLblSendCode.visible = this.cLblSafetyCode.visible = this.cTxtSafetyCode.visible = true; }
                    else { this.cLblSendCode.visible = this.cLblSafetyCode.visible = this.cTxtSafetyCode.visible = false; }
                    this.pVerifyTextbox.add(this.cLblName, this.cTxtName, true, this.$identity().regUserName, $byUser.object.ByUserStrings.Info_UserName_Pattern_Invalid(), 32);
                    this.pVerifyTextbox.add(this.cLblMobile, this.cTxtMobile, true, this.$identity().pRegMobile, $byUser.object.ByUserStrings.Info_Phone_Must_11_Digits(), 11);
                    this.pVerifyTextbox.add(this.cLblMail, this.cTxtMail, true, this.$identity().pRegMaile, $byUser.object.ByUserStrings.Info_Email_Invalid(), 32);
                    this.pVerifyTextbox.add(this.cLblPwd, this.cTxtPwd, true, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.pVerifyTextbox.add(this.cLblConfirmPwd, this.cTxtConfirmPwd, true, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.cTxtName.leave.$add(this.$access("cTxtName_leave"));
                    this.cTxtMobile.leave.$add(this.$access("cTxtMobile_leave"));
                    this.cTxtMail.leave.$add(this.$access("cTxtMail_leave"));
                    this.cTxtPwd.leave.$add(this.$access("cTxtPwd_leave"));
                    this.cTxtConfirmPwd.leave.$add(this.$access("cTxtConfirmPwd_leave"));
                    this.cLblSendCode.click.$add(this.$access("cLblSendCode_click"));
                    this.cBtnReg.click.$add(this.$access("reg"));
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_diUserReg_Title();
                    this.cLblName.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblName_Text();
                    this.cLblPwd.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblPwd_Text();
                    this.cLblConfirmPwd.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblConfirmPwd_Text();
                    this.cLblMobile.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblMobile_Text();
                    this.cLblMail.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblMail_Text();
                    this.cLblSafetyCode.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblSafetyCode_Text();
                    this.cLblSendCode.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cLblSendCode_Text();
                    this.cBtnReg.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cBtnReg_Text();
                    this.cBtnCancel.text = $byUser.object.ByUserStrings.UI_user_diUserReg_cBtnCancel_Text();
                }
                async cLblSendCode_click(sender, args){
                    if(!this.pVerifyTextbox.verify()){ return; }
                    let tmpResultValue = await this.$identity().postSafetyReg(this.cTxtMail.text.trim(), this.cTxtMobile.text.trim());
                    if(tmpResultValue.isOk){
                        this.cBtnReg.isEnabled = true;
                        if(this.$identity().pConfigSMSCode){
                            this.cLblSafetyCode.visible = true;
                            this.cTxtSafetyCode.visible = true;
                        }
                        this.cLblSendCode.visible = false;
                        this.cLblConfirmPwd.visible = this.cLblMail.visible = this.cLblMobile.visible = this.cLblPwd.visible = this.cLblName.visible = false;
                        this.cTxtConfirmPwd.visible = this.cTxtMail.visible = this.cTxtMobile.visible = this.cTxtPwd.visible = this.cTxtName.visible = false;
                    }
                    else { await $by.object.Message.alert(Byt.String($byUser.object.ByUserStrings.Info_Send_Security_Code_Failed()) + Byt.String(tmpResultValue.info)); }
                }
                cTxtConfirmPwd_leave(sender, args){
                    if(this.cTxtPwd.text.trim() != this.cTxtConfirmPwd.text.trim()){
                        this.pVerifyTextbox.showError$1(this.cTxtConfirmPwd, $byUser.object.ByUserStrings.Info_Entered_Passwords_Not_Match());
                        return;
                    }
                    this.pUserRow.i$assign("iPassword", this.cTxtPwd.text.trim());
                }
                cTxtPwd_leave(sender, args){
                    let tmpPwdInfo = this.$identity().verifyPwd(this.cTxtPwd.text.trim());
                    if(tmpPwdInfo != null){
                        this.pVerifyTextbox.showError$1(this.cTxtPwd, tmpPwdInfo);
                        return;
                    }
                }
                async cTxtMail_leave(sender, args){
                    let tmpMail = this.cTxtMail.text.trim();
                    let tmpResultValue = await this.$identity().verifyRegMail(tmpMail);
                    if(tmpResultValue != null){
                        this.pVerifyTextbox.showError$1(this.cTxtMail, tmpResultValue);
                        return;
                    }
                }
                async cTxtMobile_leave(sender, args){
                    let tmpMobile = this.cTxtMobile.text.trim();
                    let tmpResultValue = this.$identity().verifyMobileFormat(tmpMobile);
                    if(tmpResultValue != null){
                        this.pVerifyTextbox.showError$1(this.cTxtMobile, tmpResultValue);
                        return;
                    }
                    let tmpExists = await this.$identity().verifyMobileExists(tmpMobile);
                    if(tmpExists){
                        this.pVerifyTextbox.showError$1(this.cTxtMobile, $byUser.object.ByUserStrings.Info_Phone_Already_Exists());
                        return;
                    }
                }
                async cTxtName_leave(sender, args){
                    let tmpUser = this.cTxtName.text.trim();
                    let tmpVerify = await this.$identity().verifyRegisterUser(tmpUser);
                    if(tmpVerify != null){
                        this.pVerifyTextbox.showError$1(this.cTxtName, tmpVerify);
                        return;
                    }
                    tmpVerify = await this.$identity().verifyRegisterUser(tmpUser);
                    if(tmpVerify != null){
                        this.pVerifyTextbox.showError$1(this.cTxtName, $byUser.object.ByUserStrings.Info_UserName_Invalid_Template(tmpVerify));
                        return;
                    }
                }
                async reg(sender, args){
                    if(this.$identity().pConfigSMSCode && !this.$identity().verifySafetyCodeFormat(this.cTxtSafetyCode.text.trim())){
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_SecurityCode_Not_Entered());
                        return;
                    }
                    this.pUserRow.i$assign("iID", await $byCommon.identity.general.getGuid());
                    this.pUserRow.i$assign("iName", this.cTxtName.text.trim());
                    this.pUserRow.i$assign("iPassword", this.cTxtConfirmPwd.text.trim());
                    this.pUserRow.i$assign("iMobile", this.cTxtMobile.text.trim());
                    this.pUserRow.i$assign("iMail", this.cTxtMail.text.trim());
                    if(!this.pVerifyTextbox.verify()){ return; }
                    this.pUserRsaRow.i$assign("iID", await this.$identity().rsaEncode(await $byCommon.identity.general.getGuid()));
                    this.pUserRsaRow.i$assign("iName", await this.$identity().rsaEncode(this.pUserRow.i$access("iName")));
                    this.pUserRsaRow.i$assign("iPassword", await this.$identity().rsaEncode(await this.$identity().md5Plus(this.pUserRow.i$access("iPassword"))));
                    this.pUserRsaRow.i$assign("iMobile", await this.$identity().rsaEncode(this.pUserRow.i$access("iMobile")));
                    this.pUserRsaRow.i$assign("iMail", await this.$identity().rsaEncode(this.pUserRow.i$access("iMail")));
                    this.pUserRsaRow.i$assign("iRemark", $by.object.System.currentWindow.url);
                    let tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 9, target: this.$identity(), args: [ this.pUserRsaRow, this.cTxtSafetyCode.text.trim() ], argTypes: [ Byt.Row, Byt.String ], return: $by.object.Result });
                    if(tmpResultValue.isOk){
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Register_Completed_Congratulation());
                        if(!this.regSuccess.by$equals(null)){ await this.regSuccess.$invoke(this.pUserRow); }
                        this.close();
                    }
                    else {
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Register_Failed_Template(tmpResultValue.info));
                        this.cBtnReg.isEnabled = false;
                        if(this.$identity().pConfigSMSCode){
                            this.cLblSafetyCode.visible = false;
                            this.cTxtSafetyCode.visible = false;
                        }
                        this.cLblSendCode.visible = true;
                        this.cLblConfirmPwd.visible = this.cLblMail.visible = this.cLblMobile.visible = this.cLblPwd.visible = this.cLblName.visible = true;
                        this.cTxtConfirmPwd.visible = this.cTxtMail.visible = this.cTxtMobile.visible = this.cTxtPwd.visible = this.cTxtName.visible = true;
                    }
                }
            },
            instance: { props: { pUserRow: Byt.Row, pUserRsaRow: Byt.Row, pVerifyTextbox: "byCommon.object.verifyTextbox" }, events: [ "regSuccess" ] },
            dialog: { props: { cLblName: $by.object.Label, cTxtName: $by.object.TextBox, cLblPwd: $by.object.Label, cTxtPwd: $by.object.TextBox, cLblConfirmPwd: $by.object.Label, cTxtConfirmPwd: $by.object.TextBox, cLblMobile: $by.object.Label, cTxtMobile: $by.object.TextBox, cLblMail: $by.object.Label, cTxtMail: $by.object.TextBox, cLblSafetyCode: $by.object.Label, cTxtSafetyCode: $by.object.TextBox, cLblSendCode: $by.object.Label, cBtnReg: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        user$dlForgetPwd: {
            type: class dlForgetPwd extends Byt.Dialog {
                $0(){
                    this.cTxtValue.$init($ => { $.readonly = true; });
                    this.cBtnSend.$init($ => { $.isEnabled = false; });
                    this.pVerifyTextbox = new $byCommon.object.verifyTextbox().$init($ => $.$0());
                    let tmpRd = new $by.object.RadioButton().$init($ => {
                        $.name = "user";
                        $.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_rdUserName_Text();
                    });
                    this.cRdGroup.add(tmpRd);
                    tmpRd = new $by.object.RadioButton().$init($ => {
                        $.name = "mail";
                        $.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_rdEmail_Text();
                    });
                    this.cRdGroup.add(tmpRd);
                    tmpRd = new $by.object.RadioButton().$init($ => {
                        $.name = "mobile";
                        $.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_rdPhone_Text();
                    });
                    this.cRdGroup.add(tmpRd);
                    {
                        this.width = 350;
                        this.height = 300;
                        this.cRdGroup.top = 0;
                        this.cRdGroup.left = 10;
                        this.cLblValue.top = 60;
                        this.cLblValue.left = 10;
                        this.cTxtValue.top = 100;
                        this.cTxtValue.left = 10;
                        this.cBtnSend.left = 10;
                        this.cBtnSend.top = 160;
                        this.cBtnCancel.left = 180;
                        this.cBtnCancel.top = 160;
                    }
                    this.pVerifyTextbox.add(this.cLblValue, this.cTxtValue, true, "^[\x00-\uffff]{2,32}$", "", 32);
                    this.cBtnCancel.click.$add(this.$access("cBtnCancel_click"));
                    this.cRdGroup.selectionChanged.$add(this.$access("cRdGroup_selectionChanged"));
                    this.cTxtValue.mouseUp.$add(this.$access("cTxtValue_mouseUp"));
                    this.cBtnSend.click.$add(this.$access("cBtnSend_click"));
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_Title();
                    this.cRdGroup.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_cRdGroup_Text();
                    this.cLblValue.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_cLblValue_Text();
                    this.cTxtValue.placeholder = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_cTxtValue_placeholder();
                    this.cBtnSend.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_cBtnSend_Text();
                    this.cBtnCancel.text = $byUser.object.ByUserStrings.UI_user_dlForgetPwd_cBtnCancel_Text();
                }
                async cBtnSend_click(sender, args){
                    let tmpName = this.cRdGroup.checkedButton.name;
                    let tmpVerifyInfo = false;
                    let tmpResultValue = null;
                    switch(tmpName){
                        case "user":
                            tmpVerifyInfo = await this.$identity().userExists(this.cTxtValue.text.trim());
                            if(!tmpVerifyInfo){
                                await $by.object.Message.alert($byUser.object.ByUserStrings.Info_UserName_Invalid_Or_Not_Exist());
                                return;
                            }
                            tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 22, target: this.$identity(), args: [ "user", this.cTxtValue.text.trim() ], argTypes: [ "byUser.enum.safetyCodeMode", Byt.String ], return: $by.object.Result });
                            if(tmpResultValue.isOk){ await $by.object.Message.alert(tmpResultValue.info); }
                            let tmpUserDialog = await $byUser.dialog.user$RetrievePassword.$new(this.$identity(), $ => $.$0());
                            tmpUserDialog.pUser = this.cTxtValue.text.trim();
                            await tmpUserDialog.showDialog();
                            break;
                        case "mail":
                            tmpResultValue = await this.$identity().verifyMailExists(this.cTxtValue.text.trim());
                            if(!tmpResultValue.isOk){
                                await $by.object.Message.alert(tmpResultValue.info);
                                return;
                            }
                            tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 22, target: this.$identity(), args: [ "mail", this.cTxtValue.text.trim() ], argTypes: [ "byUser.enum.safetyCodeMode", Byt.String ], return: $by.object.Result });
                            if(tmpResultValue.isOk){ await $by.object.Message.alert(tmpResultValue.info); }
                            let tmpMailDialog = await $byUser.dialog.user$RetrievePassword.$new(this.$identity(), $ => $.$0());
                            tmpMailDialog.pMail = this.cTxtValue.text.trim();
                            await tmpMailDialog.showDialog();
                            break;
                        case "mobile":
                            tmpVerifyInfo = await this.$identity().verifyMobileExists(this.cTxtValue.text.trim());
                            if(!tmpVerifyInfo){
                                await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Phone_Invalid_Or_Not_Exist());
                                return;
                            }
                            tmpResultValue = await $byUser.$remote({ kind: "SKILL", NO: 22, target: this.$identity(), args: [ "mobile", this.cTxtValue.text.trim() ], argTypes: [ "byUser.enum.safetyCodeMode", Byt.String ], return: $by.object.Result });
                            if(tmpResultValue.isOk){ await $by.object.Message.alert(tmpResultValue.info); }
                            let tmpMobileDialog = await $byUser.dialog.user$RetrievePassword.$new(this.$identity(), $ => $.$0());
                            tmpMobileDialog.pMobile = this.cTxtValue.text.trim();
                            await tmpMobileDialog.showDialog();
                            break;
                    }
                    this.close();
                }
                cTxtValue_mouseUp(sender, args){
                    let tmpName = this.cRdGroup.checkedButton.name;
                    let tmpVerifyInfo = "";
                    switch(tmpName){
                        case "user":
                            tmpVerifyInfo = this.$identity().verifyUserFormat(this.cTxtValue.text.trim());
                            if(tmpVerifyInfo != null){ this.pVerifyTextbox.showError$1(this.cTxtValue, tmpVerifyInfo); }
                            break;
                        case "mail":
                            tmpVerifyInfo = this.$identity().verifyMailFormat(this.cTxtValue.text.trim());
                            if(tmpVerifyInfo != null){ this.pVerifyTextbox.showError$1(this.cTxtValue, tmpVerifyInfo); }
                            break;
                        case "mobile":
                            tmpVerifyInfo = this.$identity().verifyMobileFormat(this.cTxtValue.text.trim());
                            if(tmpVerifyInfo != null){ this.pVerifyTextbox.showError$1(this.cTxtValue, tmpVerifyInfo); }
                            break;
                    }
                }
                cRdGroup_selectionChanged(sender, args){
                    if(this.cRdGroup.checkedButton != null){
                        this.cTxtValue.readonly = false;
                        this.cBtnSend.isEnabled = true;
                    }
                }
                cBtnCancel_click(sender, args){ this.close(); }
            },
            instance: { props: { pVerifyTextbox: "byCommon.object.verifyTextbox" } },
            dialog: { props: { cRdGroup: $by.object.RadioButtonGroup, cLblValue: $by.object.Label, cTxtValue: $by.object.TextBox, cBtnSend: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        user$RetrievePassword: {
            type: class RetrievePassword extends Byt.Dialog {
                $0(){
                    this.cTxtSafetyCode.$init($ => { $.placeholder = ""; });
                    this.cTxtPassword.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.cTxtConfirmPassword.$init($ => {
                        $.isPassword = true;
                        $.placeholder = "";
                    });
                    this.pVerifyTextbox = new $byCommon.object.verifyTextbox().$init($ => $.$0());
                    {
                        this.width = 450;
                        this.height = 300;
                        this.cLblSafetyCode.top = 0;
                        this.cLblSafetyCode.left = 80;
                        this.cTxtSafetyCode.top = 40;
                        this.cTxtSafetyCode.left = 80;
                        this.cLblPassword.top = 80;
                        this.cLblPassword.left = 80;
                        this.cTxtPassword.top = 120;
                        this.cTxtPassword.left = 80;
                        this.cLblConfirmPassword.top = 160;
                        this.cLblConfirmPassword.left = 80;
                        this.cTxtConfirmPassword.top = 200;
                        this.cTxtConfirmPassword.left = 80;
                        this.cBtnSure.top = 260;
                        this.cBtnSure.left = 120;
                        this.cBtnCancel.top = 260;
                        this.cBtnCancel.left = 220;
                    }
                    this.pVerifyTextbox.add(this.cLblSafetyCode, this.cTxtSafetyCode, true, this.$identity().pRegSafetyCode, $byUser.object.ByUserStrings.Info_SecurityCode_Not_Valid(), 4);
                    this.pVerifyTextbox.add(this.cLblPassword, this.cTxtPassword, true, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.pVerifyTextbox.add(this.cLblConfirmPassword, this.cTxtConfirmPassword, true, this.$identity().regPwd, $byUser.object.ByUserStrings.Info_Password_Pattern_Invalid(), 32);
                    this.cLblConfirmPassword.leave.$add(this.$access("cLblConfirmPassword_leave"));
                    this.cBtnSure.click.$add(this.$access("cBtnSure_click"));
                    this.cBtnCancel.click.$add(this.$access("cBtnCancel_click"));
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_Title();
                    this.cLblSafetyCode.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_cLblSafetyCode_Text();
                    this.cLblPassword.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_cLblPassword_Text();
                    this.cLblConfirmPassword.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_cLblConfirmPassword_Text();
                    this.cBtnSure.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_cBtnSure_Text();
                    this.cBtnCancel.text = $byUser.object.ByUserStrings.UI_user_RetrievePassword_cBtnCancel_Text();
                }
                cLblConfirmPassword_leave(sender, args){ this.verifyConfirmPassword(); }
                cBtnCancel_click(sender, args){ this.close(); }
                async cBtnSure_click(sender, args){
                    if(!this.pVerifyTextbox.verify() || !this.verifyConfirmPassword()){ return; }
                    let tmpSafetyCode = this.cTxtSafetyCode.text.trim();
                    let tmpPwdNewMd5 = await this.$identity().md5Plus(this.cTxtPassword.text.trim());
                    let tmpCodeMode = "user";
                    let tmpUserMobileMail = null;
                    if(this.pMail != null && this.pMail != ""){
                        tmpCodeMode = "mail";
                        tmpUserMobileMail = this.pMail;
                    }
                    else if(this.pMobile != null && this.pMobile != ""){
                        tmpCodeMode = "mobile";
                        tmpUserMobileMail = this.pMobile;
                    }
                    else if(this.pUser != null && this.pUser != ""){
                        tmpCodeMode = "user";
                        tmpUserMobileMail = this.pUser;
                    }
                    let tmpResultValue = await this.$identity().userPwdModif$1(tmpUserMobileMail, tmpCodeMode, tmpPwdNewMd5, tmpSafetyCode);
                    if(tmpResultValue.isOk){ await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Modify_Completed()); }
                    else { await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Modify_Failed_Template(tmpResultValue.info)); }
                    this.close();
                }
                verifyConfirmPassword(){
                    if(this.cTxtConfirmPassword.text != this.cTxtPassword.text){
                        this.pVerifyTextbox.showError$1(this.cTxtConfirmPassword, $byUser.object.ByUserStrings.Info_Entered_Passwords_Not_Match());
                        return false;
                    }
                    return true;
                }
            },
            instance: { props: { pVerifyTextbox: "byCommon.object.verifyTextbox", pMail: Byt.String, pMobile: Byt.String, pUser: Byt.String } },
            dialog: { props: { cLblSafetyCode: $by.object.Label, cTxtSafetyCode: $by.object.TextBox, cLblPassword: $by.object.Label, cTxtPassword: $by.object.TextBox, cLblConfirmPassword: $by.object.Label, cTxtConfirmPassword: $by.object.TextBox, cBtnSure: $by.object.Button, cBtnCancel: $by.object.Button } }
        },
        user$diUserLog: {
            type: class diUserLog extends Byt.Dialog { },
            dialog: { props: { } }
        },
        user$modifyInfo: {
            type: class modifyInfo extends Byt.Dialog {
                $0(){
                    this.pVerifyTextbox = new $byCommon.object.verifyTextbox().$init($ => $.$0());
                    {
                        this.width = 450;
                        this.height = 200;
                        this.cNameLabel.top = 0;
                        this.cNameLabel.left = 10;
                        this.cNametextBox.top = 40;
                        this.cNametextBox.left = 10;
                        this.cSureButton.top = 100;
                        this.cSureButton.left = 100;
                        this.cCancelButton.top = 100;
                        this.cCancelButton.left = 300;
                    }
                    this.pVerifyTextbox.add(this.cNameLabel, this.cNametextBox, true, this.$identity().regUserName, $byUser.object.ByUserStrings.Info_UserName_LengthOrPattern_Invalid(), 32);
                    this.cCancelButton.click.$add(this.$access("cCancelButton_click"));
                    this.cSureButton.click.$add(this.$access("cSureButton_click"));
                    this.cNametextBox.leave.$add(this.$access("cNametextBox_leave"));
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_modifyInfo_Title();
                    this.cNameLabel.text = $byUser.object.ByUserStrings.UI_user_modifyInfo_cNameLabel_Text();
                    this.cSureButton.text = $byUser.object.ByUserStrings.UI_user_modifyInfo_cSureButton_Text();
                    this.cCancelButton.text = $byUser.object.ByUserStrings.UI_user_modifyInfo_cCancelButton_Text();
                }
                async cNametextBox_leave(sender, args){
                    let tmpUser = this.cNametextBox.text.trim();
                    let tmpVerify = await this.$identity().verifyRegisterUser(tmpUser);
                    if(tmpVerify != null){
                        this.pVerifyTextbox.showError$1(this.cNametextBox, tmpVerify);
                        return;
                    }
                    tmpVerify = await this.$identity().verifyRegisterUser(tmpUser);
                    if(tmpVerify != null){
                        this.pVerifyTextbox.showError$1(this.cNametextBox, $byUser.object.ByUserStrings.Info_UserName_Invalid_Template(tmpVerify));
                        return;
                    }
                }
                async cSureButton_click(sender, args){
                    this.$identity().pSession.a.i$assign("iName", this.cNametextBox.text.trim());
                    await $byUser.$sql({ ["#sql"]: "row", number: 25, args: [ this.$identity().pSession.a ], argTypes: [ Byt.Row ] });
                    this.close();
                }
                cCancelButton_click(sender, args){ this.close(); }
            },
            instance: { props: { pVerifyTextbox: "byCommon.object.verifyTextbox" } },
            dialog: { props: { cNameLabel: $by.object.Label, cNametextBox: $by.object.TextBox, cSureButton: $by.object.Button, cCancelButton: $by.object.Button } }
        },
        user$popupUser: {
            type: class popupUser extends Byt.Dialog {
                async $1(f_returnList){
                    this.cGrid.$bindIdentity($byUser.newidentitys.user).$init($ => { $.webWidthFilled = true; });
                    if(this.$identity().rUserAdmin.isAdmin()){
                        this.cBtnSearch.click.$add(async (sender, args) => { await this.fillGrid(); });
                        await this.fillGrid();
                        this.cGrid.cellDoubleClick.$add((sender, gridCellArgs) => { this.selectReturn(f_returnList); });
                        this.cBtnOk.click.$add((sender, args) => { this.selectReturn(f_returnList); });
                    }
                    else { await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Operation_Forbidden_Must_Be_Admin()); }
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_user_popupUser_Title();
                    this.cLblKeyword.text = $byUser.object.ByUserStrings.UI_user_popupUser_cLblKeyword_Text();
                    this.cTxtKeyword.placeholder = $byUser.object.ByUserStrings.UI_user_popupUser_cTxtKeyword_Placeholder();
                    this.cBtnSearch.text = $byUser.object.ByUserStrings.UI_user_popupUser_cBtnSearch_Text();
                    this.cBtnOk.text = $byUser.object.ByUserStrings.UI_user_popupUser_cBtnOk_Text();
                }
                selectReturn(f_returnList){
                    if(this.cGrid.selectedRows.count > 0){ f_returnList.add(this.cGrid.selectedRows.$get(0)); }
                    this.close();
                }
                async fillGrid(){
                    this.cGrid.clear();
                    if(this.$identity().rUserAdmin.isAdmin()){
                        let tmpList = await this.$identity().rUserAdmin.getPopupUser(this.cTxtKeyword.text.trim());
                        if(tmpList != null && tmpList.count > 0){ this.cGrid.addRange(tmpList); }
                    }
                    else 
                        await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Operation_Forbidden_Must_Be_Admin());
                }
            },
            dialog: { props: { cLblKeyword: $by.object.Label, cTxtKeyword: $by.object.TextBox, cBtnSearch: $by.object.Button, cGrid: $by.object.Grid, cBtnOk: $by.object.Button } }
        },
        userICO$diUploadICO: {
            type: class diUploadICO extends Byt.Dialog {
                $0(){
                    this.cFilePicker.acceptType = this.$identity().getAcceptType();
                    $byCommon.identity.relatedDialog.setWidthHeight(this, 380);
                    this.cFilePicker.dock = "fill";
                    this.cFilePicker.selectionChanged.$add(async (sender, args) => {
                        if(this.cFilePicker.webFiles.count > 0){
                            let tmpExtendName = this.cFilePicker.webFiles.$get(0).name.by$matches("[^\\.]+$", "multiIgnoreCase")[0].by$toLower();
                            let tmpBytes = await this.cFilePicker.webFiles.$get(0).getBytes();
                            if(tmpBytes.length > this.$identity().pUploadUserICOFileSize){
                                await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Upload_File_To_Large(((this.$identity().pUploadUserICOFileSize / 1024) | 0)));
                                return;
                            }
                            let tmpResult = await this.$identity().fileUpload(tmpBytes, "userIco", tmpExtendName);
                            if(tmpResult.isOk)
                                await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Upload_Completed());
                            else 
                                await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Upload_Failed_Template(tmpResult.info));
                        }
                    });
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_userICO_diUploadICO_Title();
                    this.cFilePicker.text = $byUser.object.ByUserStrings.UI_userICO_diUploadICO_cFilePicker_Text();
                    this.cFilePicker.toolTip = $byUser.object.ByUserStrings.UI_userICO_diUploadICO_cFilePicker_Tooltip();
                }
            },
            dialog: { props: { cFilePicker: $by.object.FilePicker } }
        },
        userAdmin$adminManager: {
            type: class adminManager extends Byt.Dialog {
                async $0(){
                    this.cGrid.$init($ => { $.visible = false; });
                    if(this.$identity().isAdmin()){
                        this.cGrid.visible = true;
                        this.cGrid.addColumns([ new $by.object.GridColumn().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_columnUserID_Text(); }), new $by.object.GridColumn().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_columnUserName_Text(); }), new $by.object.GridColumn().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_columnUserDisplayName_Text(); }), new $by.object.GridColumn().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_columnUserPhone_Text(); }) ]);
                        let tmpList = await this.$identity().getAdmin();
                        if(tmpList != null && tmpList.count > 0){
                            for (let item of tmpList){
                                let tmpRow = new $by.object.GridRow();
                                tmpRow.add(new $by.object.GridCell().$init($ => { $.text = item.a.i$access("iID"); }));
                                tmpRow.add(new $by.object.GridCell().$init($ => { $.text = item.iName; }));
                                tmpRow.add(new $by.object.GridCell().$init($ => { $.text = item.iDisplayName; }));
                                tmpRow.add(new $by.object.GridCell().$init($ => { $.text = item.iMobile; }));
                                this.cGrid.add(tmpRow);
                            }
                        }
                        this.cGrid.contextMenu = new $by.object.ContextMenu();
                        let tmpMenuAdd = new $by.object.MenuItem().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_menuitem_AddUser_Text(); });
                        this.cGrid.contextMenu.add(tmpMenuAdd);
                        tmpMenuAdd.click.$add(async (sender, args) => { await this.add$1(); });
                        let tmpMenuDelete = new $by.object.MenuItem().$init($ => { $.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_menuitem_DeleteUser_Text(); });
                        this.cGrid.contextMenu.add(tmpMenuDelete);
                        tmpMenuDelete.click.$add(async (sender, args) => { await this.delete(); });
                        this.cBtnAdd.click.$add(async (sender, args) => { await this.add$1(); });
                        
                        this.cBtnDelete.click.$add(async (sender, args) => { await this.delete(); });
                    }
                    else { await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Operation_Forbidden_Only_Admin_Can_Manage()); }
                    this.initUI();
                }
                initUI(){
                    this.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_Title();
                    this.cBtnAdd.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_cBtnAdd_Text();
                    this.cBtnDelete.text = $byUser.object.ByUserStrings.UI_userAdmin_adminManager_cBtnDelete_Text();
                }
                async add$1(){
                    let tmpRetutnList = new $by.object.List();
                    let tmpWaitingdialog = await $byCommon.identity.relatedDialog.Loading();
                    let tmpPopupUser = await $byUser.dialog.user$popupUser.$new(this.$identity().rUser, $ => $.$1(tmpRetutnList));
                    tmpWaitingdialog.close();
                    await tmpPopupUser.showDialog();
                    if(tmpRetutnList.count > 0){
                        let tmpAdminRow = new $by.object.Row().$bindIdentity($byUser.newidentitys.userAdmin);
                        tmpAdminRow.i$assign("iID", tmpRetutnList.$get(0).i$access("iID"));
                        let tmpResultValue = await this.$identity().adminAddRemove(tmpAdminRow, "insert");
                        if(tmpResultValue.isOk){
                            let tmpRow = new $by.object.GridRow();
                            tmpRow.add(new $by.object.GridCell().$init($ => { $.text = tmpRetutnList.$get(0).i$access("iID"); }));
                            tmpRow.add(new $by.object.GridCell().$init($ => { $.text = tmpRetutnList.$get(0).i$access("iName"); }));
                            tmpRow.add(new $by.object.GridCell().$init($ => { $.text = tmpRetutnList.$get(0).i$access("iDisplayName"); }));
                            tmpRow.add(new $by.object.GridCell().$init($ => { $.text = tmpRetutnList.$get(0).i$access("iMobile"); }));
                            this.cGrid.add(tmpRow);
                            await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Add_Admin_Succeed());
                        }
                        else 
                            await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Add_Admin_Failed_Template(tmpResultValue.info));
                    }
                }
                async delete(){
                    if(this.cGrid.selectedGridRows.count > 0){
                        let tmpAdminRow = new $by.object.Row().$bindIdentity($byUser.newidentitys.userAdmin);
                        tmpAdminRow.i$assign("iID", this.cGrid.selectedGridRows.$get(0).cells.$get(0).text);
                        let tmpResultValue = await this.$identity().adminAddRemove(tmpAdminRow, "delete");
                        if(tmpResultValue.isOk){
                            this.cGrid.removeChild(this.cGrid.selectedGridRows.$get(0));
                            await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Delete_Admin_Succeed());
                        }
                        else 
                            await $by.object.Message.alert($byUser.object.ByUserStrings.Info_Delete_Admin_Failed());
                    }
                }
            },
            dialog: { props: { cGrid: $by.object.Grid, cBtnAdd: $by.object.Button, cBtnDelete: $by.object.Button } }
        }
    },
    orm: {
        user$userOrm: { tables: [ "a", "b" ], fields: { userIcoPath: Byt.String, iFileName: Byt.String, iExtendName: Byt.String }, elements: [ "a.*", "b.+", "userIcoPath", "iFileName", "iExtendName" ] },
        userAdmin$adminOrm: { tables: [ "a" ], fields: { iName: Byt.String, iDisplayName: Byt.String, iMobile: Byt.String }, elements: [ "a.+", "iName", "iDisplayName", "iMobile" ] }
    },
    tables: {
        userUpload: {
            identity: "byUser.userUpload",
            fields: {
                iD: { summary: "上传编号", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                fileName: { summary: "文件名，包括扩展名，包括相对目录", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                fileSize: { summary: "文件尺寸K", type: Byt.Int, identity: $by.identity.Attribute },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byUser.user.ID" } },
                summery: { summary: "上传说明", type: Byt.String, identity: $by.identity.Attribute },
                dT: { summary: "上传时间", type: Byt.DateTime, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "iD" ] },
            sources: { fileSize: { mode: "server", actions: [ "insert", "delete", "update", "select" ], access: "byUser.userUpload.fileSize", settings: { name: "fileSize", text: "文件尺寸K" } } }
        },
        log: {
            identity: "byUser.log",
            fields: {
                iD: { summary: "日志编号", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                sceneType: { summary: "日志产生的场景", type: $by.enum.SceneType, identity: $by.identity.Attribute },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byUser.user.ID", notNull: true } },
                userName: { summary: "用户名", type: Byt.String, identity: $by.identity.Attribute, marks: { notNull: true } },
                state: { summary: "日志分类", type: "byLog.enum.logState", identity: $by.identity.Attribute },
                ip: { summary: "ip地址", type: Byt.String, identity: $by.identity.Attribute },
                summary: { summary: "说明", type: Byt.String, identity: $by.identity.Attribute },
                dt: { summary: "登录时间", type: Byt.DateTime, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byUser.log.iD", settings: { name: "iD", text: "日志编号" } },
                sceneType: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.sceneType", settings: { name: "sceneType", text: "日志产生的场景", isArray: true, value: () => ($by.enum.SceneType.$values()) } },
                userID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.userID", settings: { name: "userID", text: "用户ID" } },
                userName: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.userName", settings: { name: "userName", text: "用户名" } },
                state: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.state", settings: { name: "state", text: "日志分类", isArray: true, value: () => ($byLog.enum.logState.$values()) } },
                ip: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.ip", settings: { name: "ip", text: "ip地址" } },
                summary: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.summary", settings: { name: "summary", text: "说明" } },
                dt: { mode: "server", actions: [ "insert", "delete", "update", "select" ], access: "byUser.log.dt", settings: { name: "dt", text: "登录时间" } }
            },
            flows: { insert: [ "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" ], update: [ "sceneType", "userID", "userName", "state", "ip", "summary", "dt" ], delete: [ "iD" ], select: [ "iD", "sceneType", "userID", "userName", "state", "ip", "summary", "dt" ], popup: [ "iD" ] },
            controls: { edit: [ "sceneType", "userID", "userName", "state", "ip", "summary", "dt" ], popup: [ "iD" ] }
        },
        user: {
            identity: "byUser.user",
            fields: {
                ID: { summary: "唯一标识", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                freeze: { summary: "是否冻结", type: Byt.Bool, identity: $by.identity.Attribute, marks: { notNull: true } },
                rank: { summary: "用户模式", type: "byUser.enum.rank", identity: $by.identity.Attribute },
                name: { summary: "用户名", type: Byt.String, identity: $by.identity.Name, marks: { notNull: true } },
                password: { summary: "密码", type: Byt.String, identity: $by.identity.Attribute, marks: { notNull: true } },
                displayName: { summary: "用户显示名", type: Byt.String, identity: $by.identity.Attribute, marks: { notNull: true } },
                mobile: { summary: "手机", type: Byt.String, identity: $by.identity.Attribute, marks: { notNull: true } },
                mail: { summary: "邮箱", type: Byt.String, identity: $by.identity.Attribute, marks: { notNull: true } },
                cerMode: { summary: "证件类别", type: "byUser.enum.cer", identity: $by.identity.Attribute },
                cerName: { summary: "证件名称", type: Byt.String, identity: $by.identity.Attribute },
                cerNO: { summary: "证件编号", type: Byt.String, identity: $by.identity.Attribute },
                money: { summary: "余额", type: Byt.Decimal, identity: $by.identity.Attribute },
                regDt: { summary: "注册日期", type: Byt.DateTime, identity: $by.identity.Attribute },
                Remark: { summary: "备注", type: Byt.String, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "ID" ] },
            sources: {
                ID: { mode: "user", actions: [ "select" ], access: "byUser.user.ID", settings: { name: "ID", text: "唯一标识" } },
                freeze: { mode: "user", actions: [ "select" ], access: "byUser.user.freeze", settings: { name: "freeze", text: "是否冻结" } },
                name: { mode: "user", actions: [ "select" ], access: "byUser.user.name", settings: { name: "name", text: "用户名" } },
                password: { mode: "user", actions: [ "select" ], access: "byUser.user.password", settings: { name: "password", text: "密码" } },
                displayName: { mode: "user", actions: [ "select" ], access: "byUser.user.displayName", settings: { name: "displayName", text: "用户显示名" } },
                mobile: { mode: "user", actions: [ "select" ], access: "byUser.user.mobile", settings: { name: "mobile", text: "手机" } },
                mail: { mode: "user", actions: [ "select" ], access: "byUser.user.mail", settings: { name: "mail", text: "邮箱" } },
                cerMode: { mode: "user", actions: [ "select" ], access: "byUser.user.cerMode", settings: { name: "cerMode", text: "证件类别" } },
                cerName: { mode: "user", actions: [ "select" ], access: "byUser.user.cerName", settings: { name: "cerName", text: "证件名称" } },
                cerNO: { mode: "user", actions: [ "select" ], access: "byUser.user.cerNO", settings: { name: "cerNO", text: "证件编号" } },
                money: { mode: "user", actions: [ "select" ], access: "byUser.user.money", settings: { name: "money", text: "余额" } },
                Remark: { mode: "user", actions: [ "select" ], access: "byUser.user.Remark", settings: { name: "Remark", text: "备注" } },
                rank: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byUser.user.rank", settings: { name: "rank", text: "用户模式", isArray: true, value: () => ($byUser.enum.rank.$values()) } }
            },
            flows: { insert: [ "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "ID", "password", "rank" ], update: [ "cerMode", "cerName", "cerNO", "displayName", "freeze", "mail", "mobile", "money", "name", "Remark", "rank" ], updatePwd: [ "password", "rank" ], delete: [ "ID" ] },
            controls: { query: [ "name", "displayName", "mobile", "mail", "cerMode", "cerName", "cerNO", "rank" ], manager: [ "ID", "freeze", "name", "password", "displayName", "mobile", "mail", "cerMode", "cerName", "cerNO", "money", "Remark", "rank" ], popup: [ "ID", "freeze", "name", "displayName", "rank" ], popupAdmin: [ "ID", "name", "displayName", "mobile", "mail" ] }
        },
        userICO: {
            identity: "byUser.userICO",
            fields: {
                iD: { summary: "用户ID", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                icoFile: { summary: "图标文件， < 50k", type: Byt.String, identity: $by.identity.Attribute, marks: { verify: { max: 5000000 } } },
                uploadDt: { summary: "上传日期", type: Byt.DateTime, identity: $by.identity.Attribute },
                fileName: { summary: "文件名", type: Byt.String, identity: $by.identity.Attribute },
                extendName: { summary: "文件扩展名或文件格式", type: Byt.String, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "iD" ] }
        },
        anonymous: {
            identity: "byUser.anonymous",
            fields: {
                iD: { summary: "session ID", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                userID: { summary: "用户ID", type: Byt.String, identity: $by.identity.Reference, marks: { ref: "byUser.user.ID" } },
                regDt: { summary: "注册日期", type: Byt.DateTime, identity: $by.identity.Attribute },
                iP: { summary: "ip地址", type: Byt.String, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byUser.anonymous.iD", settings: { name: "iD", text: "session ID" } },
                userID: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.anonymous.userID", settings: { name: "userID", text: "用户ID" } },
                regDt: { mode: "server", actions: [ "insert", "delete", "update", "select" ], access: "byUser.anonymous.regDt", settings: { name: "regDt", text: "注册日期" } },
                iP: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.anonymous.iP", settings: { name: "iP", text: "ip地址" } }
            },
            flows: { insert: [ "iD", "userID", "regDt", "iP" ], update: [ "userID", "regDt", "iP" ], delete: [ "iD" ], select: [ "iD", "userID", "regDt", "iP" ], popup: [ "iD", "iP" ] },
            controls: { edit: [ "userID", "regDt", "iP" ], popup: [ "iD", "iP" ] }
        },
        userAdmin: {
            identity: "byUser.userAdmin",
            fields: {
                iD: { summary: "管理员ID", type: Byt.String, identity: $by.identity.ID, marks: { notNull: true } },
                userMode: { summary: "管理员模式", type: "byUser.enum.adminMode", identity: $by.identity.Attribute },
                dt: { summary: "加入时间", type: Byt.DateTime, identity: $by.identity.Attribute }
            },
            marks: { primary: [ "iD" ] },
            sources: {
                iD: { mode: "user", actions: [ "select", "insert" ], access: "byUser.userAdmin.iD", settings: { name: "iD", text: "管理员ID" } },
                dt: { mode: "user", actions: [ "insert", "delete", "update", "select" ], access: "byUser.userAdmin.dt", settings: { name: "dt", text: "加入时间" } },
                userMode: { mode: "client", actions: [ "insert", "delete", "update", "select" ], access: "byUser.userAdmin.userMode", settings: { name: "userMode", text: "管理员模式", isArray: true, value: () => ($byUser.enum.adminMode.$values()) } }
            },
            flows: { insert: [ "iD", "dt", "userMode" ], update: [ "dt", "userMode" ], delete: [ "iD" ], select: [ "iD", "dt", "userMode" ], popup: [ "iD", "userMode" ] },
            controls: { edit: [ "dt", "userMode" ], popup: [ "iD", "userMode" ] }
        }
    },
    newidentitys: {
        userUpload: { type: "byUser.identity.userUpload", to: "byUser.userUpload", components: { iID: { inner: true, value: "byUser.userUpload.iD" }, iFileName: { inner: true, value: "byUser.userUpload.fileName" }, iUserID: { inner: true, value: "byUser.userUpload.userID" }, iSummery: { inner: true, value: "byUser.userUpload.summery" }, iDT: { inner: true, value: "byUser.userUpload.dT" }, rUser: "byUser.user", iFileSize: { inner: true, value: "byUser.userUpload.fileSize" } } },
        log: { type: "byLog.identity.log", to: "byUser.log", components: { iID: { inner: true, value: "byUser.log.iD" }, iSceneType: { inner: true, value: "byUser.log.sceneType" }, iUserID: { inner: true, value: "byUser.log.userID" }, iUserName: { inner: true, value: "byUser.log.userName" }, iState: { inner: true, value: "byUser.log.state" }, iIp: { inner: true, value: "byUser.log.ip" }, iSummary: { inner: true, value: "byUser.log.summary" }, iDt: { inner: true, value: "byUser.log.dt" } } },
        user: {
            type: "byUser.identity.user",
            to: "byUser.user",
            components: { iID: { inner: true, value: "byUser.user.ID" }, iFreeze: { inner: true, value: "byUser.user.freeze" }, iRank: { inner: true, value: "byUser.user.rank" }, iName: { inner: true, value: "byUser.user.name" }, iPassword: { inner: true, value: "byUser.user.password" }, iDisplayName: { inner: true, value: "byUser.user.displayName" }, iMobile: { inner: true, value: "byUser.user.mobile" }, iMail: { inner: true, value: "byUser.user.mail" }, iCerMode: { inner: true, value: "byUser.user.cerMode" }, iCerName: { inner: true, value: "byUser.user.cerName" }, iCerNO: { inner: true, value: "byUser.user.cerNO" }, iMoney: { inner: true, value: "byUser.user.money" }, iRemark: { inner: true, value: "byUser.user.Remark" }, iRegDt: { inner: true, value: "byUser.user.regDt" }, rLog: "byUser.log", rUserAdmin: "byUser.userAdmin", rAnonymous: "byUser.anonymous", rUserICO: "byUser.userICO", rUserUpload: "byUser.userUpload" },
            dialogs: { ["byUser.dialog.user$diLogin"]: { }, ["byUser.dialog.user$diModifPwd"]: { }, ["byUser.dialog.user$diUserReg"]: { }, ["byUser.dialog.user$dlForgetPwd"]: { }, ["byUser.dialog.user$RetrievePassword"]: { }, ["byUser.dialog.user$diUserLog"]: { }, ["byUser.dialog.user$popupUser"]: { cGrid: "popupAdmin" } }
        },
        userICO: { type: "byUser.identity.userICO", to: "byUser.userICO", components: { iID: { inner: true, value: "byUser.userICO.iD" }, iIcoFile: { inner: true, value: "byUser.userICO.icoFile" }, iUploadDt: { inner: true, value: "byUser.userICO.uploadDt" }, rUser: "byUser.user", iExtendName: { inner: true, value: "byUser.userICO.extendName" }, iFileName: { inner: true, value: "byUser.userICO.fileName" } } },
        anonymous: { type: "byUser.identity.anonymous", to: "byUser.anonymous", components: { iID: { inner: true, value: "byUser.anonymous.iD" }, iUserID: { inner: true, value: "byUser.anonymous.userID" }, iRegDt: { inner: true, value: "byUser.anonymous.regDt" }, iIP: { inner: true, value: "byUser.anonymous.iP" } } },
        userAdmin: { type: "byUser.identity.userAdmin", to: "byUser.userAdmin", components: { iID: { inner: true, value: "byUser.userAdmin.iD" }, iUserMode: { inner: true, value: "byUser.userAdmin.userMode" }, iDt: { inner: true, value: "byUser.userAdmin.dt" }, rUser: "byUser.user" } }
    }
}))