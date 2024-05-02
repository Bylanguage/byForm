-- 以下为数据库 byFormNew 的 sqlserver 脚本


-- 先检查当前库是否已存在，若不存在则创建
IF NOT EXISTS (SELECT * FROM master..SYSDATABASES WHERE name = 'byFormNew')
CREATE DATABASE byFormNew
GO

USE byFormNew
GO

-- 先检查当前表是否已存在，若不存在，则需要先创建表
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'formField')
CREATE TABLE [formField] (
[iD] NVARCHAR(32) DEFAULT '' NOT NULL,
[form] NVARCHAR(200) DEFAULT '',
[fieldNO] NVARCHAR(200) DEFAULT '',
[fieldName] NVARCHAR(200) DEFAULT '',
[fieldType] NVARCHAR(200) DEFAULT '',
[fieldCtrl] NVARCHAR(200) DEFAULT '',
[selectValue] NVARCHAR(1024) DEFAULT '',
[fieldMin] INT DEFAULT 0,
[fieldMax] INT DEFAULT 0,
[fieldReg] NVARCHAR(200) DEFAULT '',
[fieldRegMsg] NVARCHAR(200) DEFAULT '',
[fieldDefault] NVARCHAR(200) DEFAULT '',
[order] INT DEFAULT 0,
[notNull] BIT DEFAULT 0,
[vDataValue] INT DEFAULT 0,
[userID] NVARCHAR(200) DEFAULT '',
[summary] NVARCHAR(256) DEFAULT '')
GO

-- 添加主键
ALTER TABLE [formField] ADD PRIMARY KEY ([iD])
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-0', 'form-sign-0', '0', '姓名', 'string', 'textbox', '', 0, 64, '^[一-龥_a-zA-Z0-9]+$', '仅支持字母、数字及中文', '', 0, 1, 0, '', '姓名')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-1', 'form-sign-0', '1', '性别', 'string', 'radbutton', '男
女', 0, 64, '', '', '', 0, 1, 0, '', '单选')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-2', 'form-sign-0', '2', '年龄', 'int', 'textbox', '', 0, 120, '^[1-9]\d*$', '年龄应当为正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-3', 'form-sign-0', '3', '手机', 'string', 'textbox', '', 0, 64, '(^\d{11}$)', '非法的手机号码', '', 0, 1, 0, '', '电话')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-4', 'form-sign-0', '4', '邮箱', 'string', 'textbox', '', 0, 64, '^[\-_\w]{1,}@[\w]{1,}\.[\-_\w\.]+$', '邮箱格式非法', '', 0, 1, 0, '', '邮箱')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('sign-0-5', 'form-sign-0', '5', '身份证号码', 'string', 'textbox', '', 18, 18, '^[1-9]\d{5}(19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{3}(\d|X|x)$', '身份证号格式错误，请输入中国18位身份证号，最后位x不区分大小写', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('register-0-0', 'form-register-0', '0', '姓名', 'string', 'textbox', '', 0, 64, '^[一-龥_a-zA-Z0-9]+$', '仅支持字母、数字及中文', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('register-0-1', 'form-register-0', '1', '性别', 'string', 'radbutton', '男
女', 0, 64, '', '', '', 0, 1, 0, '', '单选')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('register-0-2', 'form-register-0', '2', '年龄', 'int', 'textbox', '', 0, 120, '^[1-9]\d*$', '年龄应当为正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('register-0-3', 'form-register-0', '3', '手机', 'string', 'textbox', '', 0, 64, '(^\d{11}$)', '非法的手机号码', '', 0, 1, 0, '', '电话')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('register-0-4', 'form-register-0', '4', '邮箱', 'string', 'textbox', '', 0, 64, '^[\-_\w]{1,}@[\w]{1,}\.[\-_\w\.]+$', '邮箱格式非法', '', 0, 1, 0, '', '邮箱')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('collect-0-0', 'form-collect-0', '0', '反馈人姓名', 'string', 'textbox', '', 0, 64, '^[^""""]*$', '不能输入单引号 及双引号', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('collect-0-1', 'form-collect-0', '1', '联系电话', 'string', 'textbox', '', 0, 64, '(^\d+[\-]\d{5,11}$)|(^\d{11}$)', '非法的手机号或固定电话号码', '', 0, 0, 0, '', '电话')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('collect-0-2', 'form-collect-0', '2', '反馈内容', 'string', 'muiltTextbox', '', 0, 1000, '^[^""]*$', '不能输入单引号', '', 0, 1, 0, '', '多行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-0', 'form-appointment-0', '0', '预约人姓名', 'string', 'textbox', '', 0, 64, '^[一-龥_a-zA-Z0-9]+$', '仅支持字母、数字及中文', '', 0, 1, 0, '', '姓名')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-1', 'form-appointment-0', '1', '预约人部门', 'string', 'dropdownList', '开发部
研发部
销售部
人事部', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-2', 'form-appointment-0', '2', '会议主题', 'string', 'textbox', '', 0, 64, '^[^""""]*$', '不能输入单引号 及双引号', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-3', 'form-appointment-0', '3', '会议开始时间', 'string', 'dateTimePicker', '', 0, 64, '', '', '', 0, 1, 0, '', '日期时间')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-4', 'form-appointment-0', '4', '会议持续时间', 'string', 'dropdownList', '30分钟
1小时
2小时
3小时', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-5', 'form-appointment-0', '5', '参会人数', 'int', 'textbox', '', 1, 3000, '^[1-9]\d*$', '请输入正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('appointment-0-6', 'form-appointment-0', '6', '备注信息', 'string', 'muiltTextbox', '', 0, 64, '^[^""]*$', '不能输入单引号', '', 0, 1, 0, '', '多行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-0', 'form-order-0', '0', '客户姓名', 'string', 'textbox', '', 0, 64, '^[一-龥_a-zA-Z0-9]+$', '仅支持字母、数字及中文', '', 0, 1, 0, '', '姓名')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-1', 'form-order-0', '1', '联系电话', 'string', 'textbox', '', 0, 64, '(^\d+[\-]\d{5,11}$)|(^\d{11}$)', '非法的手机号或固定电话号码', '', 0, 1, 0, '', '电话')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-2', 'form-order-0', '2', '订购产品名称', 'string', 'dropdownList', '产品A
产品B
产品C', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-3', 'form-order-0', '3', '订购数量', 'int', 'textbox', '', 1, 500000, '^[1-9]\d*$', '订购数量需要为正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-4', 'form-order-0', '4', '收货地址', 'string', 'muiltTextbox', '', 0, 64, '^[^""""]*$', '不能输入单引号 及双引号', '', 0, 1, 0, '', '地址')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('order-0-5', 'form-order-0', '5', '付款方式', 'string', 'dropdownList', '微信支付
支付宝
信用卡', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-0', 'form-statistics-0', '0', '姓名', 'string', 'textbox', '', 0, 64, '^[一-龥_a-zA-Z0-9]+$', '不能输入单引号 及双引号', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-1', 'form-statistics-0', '1', '性别', 'string', 'radbutton', '男
女', 0, 64, '', '', '', 0, 1, 0, '', '单选')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-2', 'form-statistics-0', '2', '年龄', 'int', 'textbox', '', 0, 120, '^[1-9]\d*$', '年龄应当为正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-3', 'form-statistics-0', '3', '身高(cm)', 'int', 'textbox', '', 50, 250, '^[1-9]\d*$', '年龄应当为正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-4', 'form-statistics-0', '4', '体重(kg,取整数)', 'int', 'textbox', '', 0, 250, '^[1-9]\d*$', '体重请取正整数', '', 0, 1, 0, '', '单行文本')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-5', 'form-statistics-0', '5', '健康状况', 'string', 'dropdownList', '健康
良好
不良', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-6', 'form-statistics-0', '6', '运动频率 ', 'string', 'dropdownList', '每天
经常
偶尔
从不', 0, 64, '', '', '', 0, 1, 0, '', '下拉')
GO

INSERT INTO [formField] ([iD], [form], [fieldNO], [fieldName], [fieldType], [fieldCtrl], [selectValue], [fieldMin], [fieldMax], [fieldReg], [fieldRegMsg], [fieldDefault], [order], [notNull], [vDataValue], [userID], [summary]) VALUES ('statistics-0-7', 'form-statistics-0', '7', '球类爱好', 'string', 'checkBoxList', '篮球
足球
羽毛球
乒乓球
排球
棒球
台球', -1, -1, '', '', '', 0, 1, 0, '', '多选')
GO

-- 先检查当前表是否已存在，若不存在，则需要先创建表
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'formTemplate')
CREATE TABLE [formTemplate] (
[ID] NVARCHAR(32) DEFAULT '' NOT NULL,
[name] NVARCHAR(32) DEFAULT '' NOT NULL,
[formID] NVARCHAR(32) DEFAULT '' NOT NULL,
[userID] NVARCHAR(200) DEFAULT '')
GO

-- 添加主键
ALTER TABLE [formTemplate] ADD PRIMARY KEY ([ID])
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-order-0', '在线订单模板', 'form-order-0', '')
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-collect-0', '意见反馈模板', 'form-collect-0', '')
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-register-0', '在线登记模板', 'form-register-0', '')
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-appointment-0', '会议预约模板', 'form-appointment-0', '')
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-sign-0', '在线登记模板', 'form-sign-0', '')
GO

INSERT INTO [formTemplate] ([ID], [name], [formID], [userID]) VALUES ('template-statistics-0', '在线统计模板', 'form-statistics-0', '')
GO

-- 先检查当前表是否已存在，若不存在，则需要先创建表
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'formData')
CREATE TABLE [formData] (
[iD] NVARCHAR(200) DEFAULT '' NOT NULL,
[formID] NVARCHAR(200) DEFAULT '',
[rowPK] NVARCHAR(200) DEFAULT '',
[fieldID] NVARCHAR(200) DEFAULT '',
[fieldName] NVARCHAR(200) DEFAULT '',
[cellValue] NVARCHAR(4000) DEFAULT '',
[userID] NVARCHAR(200) DEFAULT '')
GO

-- 添加主键
ALTER TABLE [formData] ADD PRIMARY KEY ([iD])
GO

-- 添加索引
CREATE INDEX [formData_0] ON [formData] ([formID])
GO

-- 先检查当前表是否已存在，若不存在，则需要先创建表
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'form')
CREATE TABLE [form] (
[iD] NVARCHAR(32) DEFAULT '' NOT NULL,
[name] NVARCHAR(200) DEFAULT '' NOT NULL,
[successMsg] NVARCHAR(200) DEFAULT '谢谢，我们会尽快处理！',
[submitButton] NVARCHAR(200) DEFAULT '确认提交',
[summary] NVARCHAR(256) DEFAULT '' NOT NULL,
[userID] NVARCHAR(200) DEFAULT '',
[createDt] DATETIME2 DEFAULT CURRENT_TIMESTAMP,
[currentModifyDt] DATETIME2 DEFAULT CURRENT_TIMESTAMP)
GO

-- 添加主键
ALTER TABLE [form] ADD PRIMARY KEY ([iD])
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-sign-0', '在线报名', '已收到您的报名信息，我们将在7个工作日内给您反馈！', '确认报名', '', '', '2024-04-28', '2024-04-28')
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-register-0', '在线登记', '感谢！已收到您的登记信息。', '确认登记', '', '', '2024-04-28', '2024-04-28')
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-collect-0', '意见反馈', '感谢您的宝贵意见,我们会尽快处理！', '确认提交', '', '', '2024-04-28', '2024-04-28')
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-appointment-0', '会议预约', '已收到您的预约信息，我们将尽快给您反馈！', '确认预约', '', '', '2024-04-28', '2024-04-28')
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-order-0', '在线订单', '谢谢,我们会尽快与您联系！', '确认订购', '', '', '2024-04-28', '2024-04-28')
GO

INSERT INTO [form] ([iD], [name], [successMsg], [submitButton], [summary], [userID], [createDt], [currentModifyDt]) VALUES ('form-statistics-0', '调查统计', '收到，感谢您的参与', '确认提交', '', '', '2024-04-28', '2024-04-28')
GO

-- 先检查当前表是否已存在，若不存在，则需要先创建表
IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'fieldTemplate')
CREATE TABLE [fieldTemplate] (
[iD] NVARCHAR(32) DEFAULT '' NOT NULL,
[name] NVARCHAR(32) DEFAULT '' NOT NULL,
[summary] NVARCHAR(32) DEFAULT '',
[ctrType] NVARCHAR(200) DEFAULT '',
[ico] NVARCHAR(128) DEFAULT '',
[min] INT DEFAULT 0,
[max] INT DEFAULT 0,
[default2] NVARCHAR(32) DEFAULT '',
[reg] NVARCHAR(256) DEFAULT '',
[regMsg] NVARCHAR(256) DEFAULT '',
[createDt] DATETIME2 DEFAULT CURRENT_TIMESTAMP)
GO

-- 添加主键
ALTER TABLE [fieldTemplate] ADD PRIMARY KEY ([iD])
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('1', 'singleTextbox', '单行文本', 'textbox', 'singleTextbox.svg', 0, 0, '', '^[^""""]*$', '不能输入单引号 及双引号', '2024-04-28 00:00:00')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('2', 'multiTextbox', '多行文本', 'muiltTextbox', 'multiTextbox.svg', 0, 0, '', '^[^""]*$', '不能输入单引号', '2024-04-28 00:00:10')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('3', 'checkBox', '判断', 'checkBox', 'checkBox.svg', 0, 0, '', '', '', '2024-04-28 00:00:20')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('4', 'dropdownList', '下拉', 'dropdownList', 'dropdownList.svg', 0, 0, '', '', '', '2024-04-28 00:00:30')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('5', 'radbutton', '单选', 'radbutton', 'radbutton.svg', 0, 0, '', '', '', '2024-04-28 00:00:40')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('6', 'checkBoxList', '多选', 'checkBoxList', 'checkBoxList.svg', 0, 0, '', '', '', '2024-04-28 00:00:50')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('7', 'name', '姓名', 'textbox', 'name.svg', 0, 0, '', '^[一-龥_a-zA-Z0-9]+$', '仅支持字母、数字及中文', '2024-04-28 00:01:00')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('8', 'address', '地址', 'muiltTextbox', 'address.svg', 0, 0, '', '^[^""""]*$', '不能输入单引号 及双引号', '2024-04-28 00:01:10')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('9', 'telephone', '电话', 'textbox', 'telephone.svg', 0, 0, '', '(^\d+[\-]\d{5,11}$)|(^\d{11}$)', '非法的手机号或固定电话号码', '2024-04-28 00:01:20')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('10', 'mail', '邮箱', 'textbox', 'mail.svg', 0, 0, '', '^[\-_\w]{1,}@[\w]{1,}\.[\-_\w\.]+$', '邮箱格式非法', '2024-04-28 00:01:30')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('11', 'summary', '说明', 'muiltTextbox', 'summary.svg', 0, 0, '', '^[^""]*$', '不能输入单引号', '2024-04-28 00:01:40')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('12', 'NO', '编号', 'textbox', 'no.svg', 0, 0, '', '^[_\-0-9a-zA-Z]+$', '仅支持字母、数字及"-_"', '2024-04-28 00:01:50')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('13', 'decimal', '小数', 'textbox', 'decimal.svg', 0, 0, '', '(^\-?[\d]+$)|(^\-?[\d]+\.[\d]+$)', '非法的小数格式', '2024-04-28 00:02:00')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('14', 'date', '日期', 'datePicker', 'date.svg', 0, 0, '', '', '', '2024-04-28 00:02:10')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('15', 'time', '时间', 'timePicker', 'time.svg', 0, 0, '', '', '', '2024-04-28 00:02:20')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('16', 'datetime', '日期时间', 'dateTimePicker', 'datetime.svg', 0, 0, '', '', '', '2024-04-28 00:02:30')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('17', 'money', '货币', 'textbox', 'money.svg', 0, 0, '', '(^\-?[\d]+$)|(^\-?[\d]+\.[\d]+$)', '非法的金额', '2024-04-28 00:02:40')
GO

INSERT INTO [fieldTemplate] ([iD], [name], [summary], [ctrType], [ico], [min], [max], [default2], [reg], [regMsg], [createDt]) VALUES ('18', 'slider', '滑块', 'slider', 'slider.svg', 0, 0, '', '', '', '2024-04-28 00:02:50')
GO

