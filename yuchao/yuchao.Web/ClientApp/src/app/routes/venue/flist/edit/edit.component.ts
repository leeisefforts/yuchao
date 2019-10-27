import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { UploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './edit.component.html',
})
export class flistEditComponent  {
   showUploadList = {
      showPreviewIcon: true,
      showRemoveIcon: true,
      hidePreviewIconInNonImage: true
    };
    fileList = [
      {
        uid: -1,
        name: 'xxx.png',
        status: 'done',
        url: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png'
      }
    ];
    previewImage: string | undefined = '';
    previewVisible = false;
  record: any = {};
  schema: SFSchema = {
    properties: {
      venueName: { type: 'string', title: '场馆名称', maxLength: 50 },
      venueAddress: {
        type: 'string',
        title: '场馆地址',
        ui: {
          widget: 'textarea',
          autosize: { minRows: 1, maxRows: 4 },
        },
      },
      avePrice: { type: 'string', title: '场馆均价', maxLength: 50 },
      lng: { type: 'string', title: '经度', maxLength: 50 },
      lat: { type: 'string', title: '纬度', maxLength: 50 },
    },
    required: ['venueName','venueAddress', 'avePrice','lng','lat'],
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
    this.modal.destroy();
  }
  handlePreview = (file: UploadFile) => {
      this.previewImage = file.url || file.thumbUrl;
      this.previewVisible = true;
    };
}
