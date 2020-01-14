import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { UploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './edit.component.html',
})
export class refereeEditComponent  {
   showUploadList = {
         showPreviewIcon: true,
         showRemoveIcon: true,
         hidePreviewIconInNonImage: true
       };
       fileList: any = [];
       previewImage: string | undefined = '';
       previewVisible = false;
       record: any = {};
       schema: SFSchema = {
       properties: {
         siteName: { type: 'string', title: '场地名称', maxLength: 50 },
         price: { type: 'number', title: '场地均价',minimum:0, maximum:10000, pattern : '/^\d+(\.\d{0,2})?$/'},

       },
       required: ['siteName', 'price'],
       ui: {
         spanLabelFixed: 150,
         grid: { span: 24 },
       },
     };

     constructor(private modal: NzModalRef, private msgSrv: NzMessageService) {}
     save(value: any) {
       this.msgSrv.success('保存成功');
       this.modal.close(value);
     }

     close() {
       this.modal.close();
     }
   }
