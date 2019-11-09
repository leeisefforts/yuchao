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
    fileList: any = [];
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
      avePrice: { type: 'number', title: '场馆均价',minimum:0, maximum:10000, pattern : '/^\d+(\.\d{0,2})?$/'},
      lng: { type: 'string', title: '经度'},
      lat: { type: 'string', title: '纬度'},

    },
    required: ['venueName','venueAddress', 'avePrice','lng','lat'],
    ui: {
      spanLabelFixed: 150,
      grid: { span: 24 },
    },
  };

  constructor(private modal: NzModalRef, private msgSrv: NzMessageService) {}
  ngOnInit(): void {
    let {venueImg} = this.record
    if(!!venueImg){
      let file = {
        url:venueImg,
      }
      this.fileList.push(file)
    }
  }
  save(value: any) {
    this.msgSrv.success('保存成功');
    this.modal.close(value);
  }

  close() {
    this.modal.close();
  }
  handleBefore =  (file) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        console.log("venueImg",reader.result)
        this.record.venueImg = reader.result
      };
      return true
  }
  handlePreview = (file: UploadFile): void => {
    this.previewImage = file.url || file.thumbUrl;
    this.previewVisible = true;
  };
}
