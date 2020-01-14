import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { UploadFile } from 'ng-zorro-antd/upload';

@Component({
    selector: 'app-basic-list-edit',
    templateUrl: './account.component.html',
})
export class flistAccountComponent {
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
            account: { type: 'string', title: '账号名' },
            pwd: { type: 'string', title: '密码', format: 'password' },

        },
        required: ['pwd', 'account'],
        ui: {
            spanLabelFixed: 150,
            grid: { span: 24 },
        },
    };

    constructor(private modal: NzModalRef, private msgSrv: NzMessageService) { }
    ngOnInit(): void {
        let { account, pwd } = this.record

    }


    getVenueAccount() {

    }

    setVenueAccount() {

    }

    save(value: any) {
        this.msgSrv.success('保存成功');
        this.modal.close(value);
    }

    close() {
        this.modal.close();
    }

}
