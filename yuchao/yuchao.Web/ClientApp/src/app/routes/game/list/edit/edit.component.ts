import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { UploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './edit.component.html',
})
export class listEditComponent  {

   showUploadList = {
         showPreviewIcon: true,
         showRemoveIcon: true,
         hidePreviewIconInNonImage: true
       };
       fileList: any = [];
       previewImage: string | undefined = '';
       previewVisible = false;
       record: any = {};
       selectList: any = {};
       schema: SFSchema = {
       properties: {

       },
       required: [],
       ui: {
         spanLabelFixed: 150,
         grid: { span: 24 },
       },
     };

     constructor(
      private modal: NzModalRef,
      private msgSrv: NzMessageService) {
     }
      onChange(result: Date): void {
         console.log('onChange: ', result);
       }
     save(value: any) {
       this.msgSrv.success('保存成功');
       this.modal.close(value);
     }

     close() {
       this.modal.close();
     }
   }
