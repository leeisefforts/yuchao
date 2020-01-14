import { Component, ViewChild, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, HostListener, Inject, ElementRef } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { STComponent, STColumn, STData, STChange } from '@delon/abc';
import { NzInputDirective } from 'ng-zorro-antd/input';
import { flistEditComponent } from './edit/edit.component';
import { flistAccountComponent } from './account/account.component';
import { priceEditComponent } from './edit/price.component';
import { debug } from 'util';
interface ItemData {
    id: string;
    venueName: string;
    venueAddress: string;
    avePrice: string;
    score: string;
    venueImg: string;
    lng: string;
    lat: string;
    checked: boolean;
    disabled?: boolean;
}

@Component({
    selector: 'app-venue-flist',
    templateUrl: './venue-flist.component.html',
    styleUrls: ['./venue-flist.component.less'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class VenueFlistComponent implements OnInit {
    listOfData: ItemData[] = [];
    loading = false;
    baseUrl: string;
    listOfDisplayData: ItemData[] = [];
    //页码
    q: any = {
        pi: 1,
        ps: 10,
        sorter: '',
        venueName: ''
    };
    constructor(
        private http: _HttpClient,
        public msg: NzMessageService,
        private modalSrv: NzModalService,
        private modal: ModalHelper,
        private cdr: ChangeDetectorRef,
        private msgSrv: NzMessageService,
        @Inject('BASE_URL') baseUrl: string,
    ) {
        // this.baseUrl = baseUrl;
        this.baseUrl = "https://nestmiu.com:8081"
    }

    ngOnInit(): void {
        this.getData();
    }
    /**
     * 获取列表数据
     */
    getData() {
        this.loading = true;

        this.http
            .get(this.baseUrl + '/api/admin/Venue', this.q)
            .pipe(
                map((res: any) =>
                    res.obj.map(i => {
                        return i;
                    }),
                ),
                tap(() => (this.loading = false)),
            )
            .subscribe(res => {
                console.log("res", res)
                this.listOfData = res;
                this.cdr.detectChanges();
            });
    }
    currentPageDataChange($event: ItemData[]): void {
        this.listOfDisplayData = $event;
    }
    /**
     * 编辑行
     */
    editHttp(params) {
        this.http.post(this.baseUrl + '/api/admin/Venue', params).subscribe(res => {
            this.getData()
        });
    }
    openEdit(record: any = {}) {
        this.modal.create(flistEditComponent, { record }, { size: 'md' }).subscribe(res => {
            if (!record.id) {
                res.id = 0
            }
            res.venueImg = record.venueImg
            res.score = !!record.score ? record.score : 0
            this.editHttp(res)
            this.cdr.detectChanges();
        });
    }

    openSetAccount(record: any = {}) {
        this.modal.create(flistAccountComponent, { record }, { size: 'md' }).subscribe(res => {
            if (!record.id) {
                res.id = 0
            }
            res.account = record.account
            this.accountHttp(res)
            this.cdr.detectChanges();
        });
    }
    /**
     * 删除行
     */
    handleDel(id) {
        this.http.delete(this.baseUrl + '/api/admin/Venue/' + id).subscribe(res => {
            this.getData()
            this.msgSrv.success('删除成功');
        });
    }

    accountHttp(res) {
        let { id, account, pwd } = res
        debugger;
        this.http.post(this.baseUrl + '/api/admin/venue/setAccount/' + id, { account, pwd }).subscribe(res => {
            this.getData()
        });
    }

    /**
     * 设置价格
     */
    priceHttp(res) {
        let { id, mPrice, aPrice, nPrice } = res
        this.http.post(this.baseUrl + '/api/admin/siteApi/setPrice/' + id, { mPrice, aPrice, nPrice }).subscribe(res => {
            this.getData()
        });
    }
    handlePrice(record: any = {}) {
        this.modal.create(priceEditComponent, { record }, { size: 'md' }).subscribe(res => {
            this.priceHttp(res)
            this.cdr.detectChanges();
        });
    }
}
