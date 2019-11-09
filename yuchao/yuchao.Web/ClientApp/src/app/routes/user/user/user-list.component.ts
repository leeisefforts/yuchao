import { Component, ViewChild, OnInit, ChangeDetectionStrategy, ChangeDetectorRef,HostListener, Inject,ElementRef } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { STComponent, STColumn, STData, STChange } from '@delon/abc';
import { NzInputDirective } from 'ng-zorro-antd/input';
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
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserListComponent implements OnInit {
  listOfData: ItemData[] = [];
  loading = false;
  baseUrl: string;
  listOfDisplayData: ItemData[] = [];
  //页码
  q: any = {
    pi: 1,
    ps: 10,
    sorter: '',
    nickName:''
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
    this.baseUrl = "https://fragmenttime.com:8081"
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
      .get(this.baseUrl + '/api/admin/User', this.q)
      .pipe(
        map((res: any) =>
          res.obj.map(i => {
            return i;
          }),
        ),
        tap(() => (this.loading = false)),
      )
      .subscribe(res => {
        this.listOfData = res;
        this.cdr.detectChanges();
      });
  }
 currentPageDataChange($event: ItemData[]): void {
   this.listOfDisplayData = $event;
 }
  /**
   * 删除行
   */
  handleDel(id){
    this.http.delete(this.baseUrl +'/api/admin/User').subscribe(res => {
      this.getData()
      this.msgSrv.success('删除成功');
    });
  }
}
