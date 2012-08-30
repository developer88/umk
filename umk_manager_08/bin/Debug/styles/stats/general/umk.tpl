<!--Statistic Style v1.0 for Developer's UMK MANAGER by Eremin Andrew 2009-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<title>СТАТИСТИКА {STAT_TYPE}</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<body bgcolor="#FFFFFF">
<strong>
	<font color="#000000" size="5">{INST} . {CAF_NAME} . {UMK_NAME}</font><br>
</strong>
<font size="2"><strong>Дата создания:</strong>
<em>{DATE}</em>.
<strong>Зав. кафедры:</strong> {CAF_DIRECTOR} 
<br>
<strong>Директор:</strong> {DIRECTOR}
<strong>Ответственный за УМК:</strong> {UMK_DIRECTOR}
<br>
<hr>
<strong>Автор УМК:</strong> {UMK_AUTHOR}
<br>
<strong>УМК закреплено за:</strong> {UMK_ATTACHED}
<br>
<strong>Количество лекций:</strong> {UMK_LECTURE}
<strong>Количество часов:</strong> {UMK_HOURS}
<hr><strong>Экзамен: <img src="stat_files/img_{UMK_EXAM}.jpg"></strong> <br>
<strong>Зачёт: <img src="stat_files/img_{UMK_TEST}.jpg"></strong><br>
<strong>Контрольная работа: <img src="stat_files/img_{UMK_EXAMINATION}.jpg"></strong><br>
<strong>Курсовой проект: <img src="stat_files/img_{UMK_PRJ}.jpg"></strong></font>
<br><br>
<table width="100%" border="1" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="40">
    	<div align="center"><strong>№</strong></div>
    </td>
    <td width="160">
    	<div align="center"><strong>Название файла</strong></div>
    </td>
    <td width="100">
    	<div align="center"><strong>Типа файла</strong></div>
    </td>
    <td width="400">
    	<div align="center"><strong>Описание файла</strong></div>
    </td>
  </tr>  
    {INSERT} 
</table>
</body>
</html>
