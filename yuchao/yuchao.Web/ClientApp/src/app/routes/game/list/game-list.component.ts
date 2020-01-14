import { Component, ViewChild, OnInit, ChangeDetectionStrategy, ChangeDetectorRef,HostListener, Inject,ElementRef } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { STComponent, STColumn, STData, STChange } from '@delon/abc';
import { NzInputDirective } from 'ng-zorro-antd/input';
import { listEditComponent } from './edit/edit.component';
interface ItemData {
  venueId: string;
  siteName:string;
  Price: string;
}

@Component({
  selector: 'app-venue-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GameListComponent implements OnInit {
  listOfData: ItemData[] = [];
  selectList: ItemData[] = [];
  venueId: string;
  loading = false;
  baseUrl: string;
  //选择行
  listOfDisplayData: ItemData[] = [];
  isAllDisplayDataChecked = false;
  isIndeterminate = false;
  //页码
  q: any = {
    pi: 1,
    ps: 10,
    sorter: '',
  };
  selectedRows: STData[] = [];
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
    this.getSelectData()
  }
  /**
   * 获取列表数据
   */
  getData() {
    this.loading = true;
    this.http
      .get(this.baseUrl + '/api/admin/Gamerecord/1', this.q)
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
  /**
   * 获取场馆选择列表
   */
  getSelectData() {
    this.http
      .get(this.baseUrl + '/api/admin/venue/VenueApi',{})
      .pipe(
        map((res: any) =>
          res.obj.map(i => {
            return i;
          }),
        ),
        tap(),
      )
      .subscribe(res => {
        this.selectList = res;
        this.venueId = !!res[0]?res[0].id:''
        this.getData()
      });
  }
  /**
   * 编辑行
   */
  editHttp(params){
    this.http.post(this.baseUrl +'/api/admin/Gamerecord', params).subscribe(res => {
      this.getData()
    });
  }
  currentPageDataChange($event: ItemData[]): void {
    this.listOfDisplayData = $event;
  }
  openEdit(record: any = {}) {
    let {selectList} = this
    this.modal.create(listEditComponent, { record,selectList }, { size: 'md' }).subscribe(res => {
      if (!record.id) {
        res.id = 0
        res.venueId = selectList[0].venueId
        res.gameTime = Date()
      }
      this.editHttp(res)
      this.cdr.detectChanges();
    });
  }
  /**
   * 删除行
   */
  handleDel(id){
    this.http.delete(this.baseUrl +'/api/admin/Gamerecord/'+id).subscribe(res => {
      this.msgSrv.success('删除成功');
      this.getData()
    });
  }
  }
