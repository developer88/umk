<!--Statistic Style v1.0 for Developer's UMK MANAGER by Eremin Andrew 2009-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<title>СТАТИСТИКА {STAT_TYPE}</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<body bgcolor="#FFFFFF">
<strong>
	<font color="#000000" size="5">{INST}</font><br>
</strong>
<font size="2"><strong>Дата создания:</strong>
<em>{DATE}</em>
<br>
<strong>Директор:</strong> {DIRECTOR}
<strong>Ответственный за УМК:</strong> {UMK_DIRECTOR}
</font>
<br><br>
<table width="100%" border="1" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="40">
    	<div align="center"><strong>№</strong></div>
    </td>
    <td width="400">
    	<div align="center"><strong>Название кафедры</strong></div>
    </td>
    <td width="300">
    	<div align="center"><strong>Зав. кафедры</strong></div>
    </td>
  </tr>  
    {INSERT} 
     
</table>
</body>
</html>
