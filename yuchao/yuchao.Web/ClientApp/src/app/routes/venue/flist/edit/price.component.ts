import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './price.component.html',
})
export class priceEditComponent  {
  record: any = {};
  schema: SFSchema = {
    properties: {
      mPrice: { type: 'number', title: '上午场价格',minimum:0, maximum:10000, pattern : '/^\d+(\.\d{0,2})?$/'},
      aPrice: { type: 'number', title: '下午场价格',minimum:0, maximum:10000, pattern : '/^\d+(\.\d{0,2})?$/'},
      nPrice: { type: 'number', title: '晚场价格',minimum:0, maximum:10000, pattern : '/^\d+(\.\d{0,2})?$/'},
    },
    required: ['mPrice','aPrice', 'nPrice'],
    ui: {
      spanLabelFixed: 150,
      grid: { span: 24 },
    },
  };

  constructor(private modal: NzModalRef, private msgSrv: NzMessageService) {}
  ngOnInit(): void {
  }
  save(value: any) {
    this.msgSrv.success('保存成功');
    this.modal.close(value);
  }

  close() {
    this.modal.close();
  }
}
