
-- 妇幼平台.项目对照表 
create table t_def_wacitem 
(
       platgroupid						varchar2(30)			not null,
       platgroupname						varchar2(200)			not null,
       hisgroupid						varchar2(30)			not null,
       hisgroupname						varchar2(200)			not null,
       platitemid						varchar2(30)			not null,
       platitemname						varchar2(200)			not null,
       hisitemid						varchar2(30)			not null,
       hisitemname						varchar2(200)			not null,
       constraint pk_t_def_wacitem primary key ( hisgroupid, hisitemid )    
);

-- 妇幼平台.已上传记录 
create table t_opr_bih_wacrecord
(
       registerid             varchar2(12)        not null,
       inpatientid            varchar2(12)        not null,
       inpatientdate          date                not null,
       uploaddate             date                not null,
       constraint pk_t_opr_bih_wacrecord primary key ( registerid )    
);

create index idx_wacrecord_uploaddate on t_opr_bih_wacrecord ( uploaddate );


select a.registerid, a.inpatientid, a.inpatientdate, a.uploaddate
  from t_opr_bih_wacrecord a
 where (a.uploaddate between
       to_date('2014-10-01 00:00:00', 'yyyy-mm-dd hh24:mi:ss') and
       to_date('2014-10-30 00:00:00', 'yyyy-mm-dd hh24:mi:ss'));
       
select a.registerid, a.inpatientid, a.inpatientdate, a.uploaddate
  from t_opr_bih_wacrecord a
 where (a.uploaddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss'));


select a.*
  from inpatmedrec_item a
 inner join t_bse_hisemr_relation b
    on a.inpatientid = b.emrinpatientid
   and a.inpatientdate = b.emrinpatientdate
 inner join t_opr_bih_register c
    on b.registerid_chr = c.registerid_chr
 where a.typeid = 'frmIMR_childbirth'
   and a.itemid = 'dateTimePicker3';

select a.inpatientid, a.inpatientdate, a.opendate
  from inpatmedrec a
 where a.typeid = 'frmIMR_childbirth'
   and a.status = '0'
   and (a.opendate between
       to_date('2014-10-01 00:00:00', 'yyyy-mm-dd hh24:mi:ss') and
       to_date('2014-10-30 00:00:00', 'yyyy-mm-dd hh24:mi:ss'));
       
select a.inpatientid, a.inpatientdate, a.opendate
  from inpatmedrec a
 where a.typeid = 'frmIMR_childbirth'
   and a.status = '0'
   and (a.opendate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
       to_date(?, 'yyyy-mm-dd hh24:mi:ss'));

-- (TYPEID, INPATIENTID, INPATIENTDATE, OPENDATE, ITEMID)

-- (TYPEID, INPATIENTID, INPATIENTDATE, OPENDATE)




--select * from inpatmedrec t where t.typeid = 'frmIMR_childbirth';

 
