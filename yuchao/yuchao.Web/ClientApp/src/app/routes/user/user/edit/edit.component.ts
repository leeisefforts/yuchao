import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { UploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './edit.component.html',
})
export class userEditComponent  {
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
      nickName: { type: 'string', title: '用户名', maxLength: 50 },
      tel: { type: 'string', title: '手机号', pattern : '/^\d+(\.\d{0,2})?$/'},
    },
    required: ['nickName','tel'],
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
