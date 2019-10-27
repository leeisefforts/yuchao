import { Component, ViewChild, OnInit, ChangeDetectionStrategy, ChangeDetectorRef,HostListener, Inject,ElementRef } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { STComponent, STColumn, STData, STChange } from '@delon/abc';
import { NzInputDirective } from 'ng-zorro-antd/input';
import { flistEditComponent } from './edit/edit.component';
interface ItemData {
  id: string,
  venueName: string,
  venueAddress: string,
  avePrice: string,
  score: string,
  venueImg: string,
  lng: string,
  lat: string
}

@Component({
  selector: 'app-venue-flist',
  templateUrl: './venue-flist.component.html',
  styleUrls: ['./venue-flist.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class VenueFlistComponent implements OnInit {
  editCache: { [key: string]: { edit: boolean; data: ItemData } } = {};
  listOfData: ItemData[] = [];

  isAllDisplayDataChecked = false;
  isOperating = false;
  isIndeterminate = false;
  listOfDisplayData: ItemData[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;

  defaultFileList = [
    {
      uid: -1,
      name: 'xxx.png',
      status: 'done',
      url: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png',
      thumbUrl: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png'
    }
  ]
  fileList = [...this.defaultFileList];

  q: any = {
    pi: 1,
    ps: 10,
    sorter: '',
  };

  loading = false;

  selectedRows: STData[] = [];
  description = '';
  totalCallNo = 0;
  expandForm = false;
  baseUrl: string;
  constructor(
    private http: _HttpClient,
    public msg: NzMessageService,
    private modalSrv: NzModalService,
     private modal: ModalHelper,
    private cdr: ChangeDetectorRef,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    // this.baseUrl = baseUrl;
    this.baseUrl = "https://fragmenttime.com:8081"
  }

  ngOnInit(): void {
    console.log("url",this.baseUrl);
    this.getData();
  }
  /**
   * 获取列表数据
   */
  getData() {
    this.loading = true;

    this.http
      .get(this.baseUrl + '/api/admin/venue/VenueApi', this.q)
      .pipe(
        map((res: any) =>
          res.obj.map(i => {
            return i;
          }),
        ),
        tap(() => (this.loading = false)),
      )
      .subscribe(res => {
         console.log("res",res);
        this.listOfData = res;
        this.cdr.detectChanges();
      });
  }
  //选择行
  refreshStatus(): void {
    this.isAllDisplayDataChecked = this.listOfDisplayData.every(item => this.mapOfCheckedId[item.id]);
    this.isIndeterminate = this.listOfDisplayData.some(item => this.mapOfCheckedId[item.id]) && !this.isAllDisplayDataChecked;
  }
 /**
  * 全选
  */
  checkAll(value: boolean): void {
    this.listOfDisplayData.forEach(item => (this.mapOfCheckedId[item.id] = value));
    this.refreshStatus();
  }
  /**
   * 编辑行
   */
  openEdit(record: any = {}) {
    this.modal.create(flistEditComponent, { record }, { size: 'md' }).subscribe(res => {
      if (record.id) {
        record = { ...record, id: 'mock_id', percent: 0, ...res };
         console.log("record",record)
      } else {
        this.listOfData.splice(0, 0, res);
        this.listOfData = [...this.listOfData];
      }
      this.cdr.detectChanges();
    });
  }
}
