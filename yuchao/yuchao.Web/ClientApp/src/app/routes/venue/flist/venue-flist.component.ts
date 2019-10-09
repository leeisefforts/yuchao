import { Component, ViewChild, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, Inject } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { STComponent, STColumn, STData, STChange } from '@delon/abc';

@Component({
  selector: 'app-venue-flist',
  templateUrl: './venue-flist.component.html',
  styleUrls: ['./venue-flist.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class VenueListComponent implements OnInit {
  q: any = {
    pi: 1,
    ps: 10,
    sorter: '',
    status: null,
    statusList: [],
  };
  data: any[] = [];
  loading = false;
  status = [
    { index: 0, text: '关闭', value: false, type: 'default', checked: false },
    {
      index: 1,
      text: '运行中',
      value: false,
      type: 'processing',
      checked: false,
    },
    { index: 2, text: '已上线', value: false, type: 'success', checked: false },
    { index: 3, text: '异常', value: false, type: 'error', checked: false },
  ];
  @ViewChild('st', { static: true })
  st: STComponent;
  columns: STColumn[] = [
    { title: '', index: 'key', type: 'checkbox' },
    { title: '场馆名称', index: 'venueName' },
    { title: '场馆地址', index: 'venueAddress' },
    {
      title: '场馆均价',
      index: 'avePrice',
      type: 'number',
    },
    {
      title: '场馆评分',
      index: 'score',
    },
    {
      title: '状态',
      index: 'status',
      render: 'status',
      filter: {
        menus: this.status,
        fn: (filter: any, record: any) => record.status === filter.index,
      },
    },
    {
      title: '操作',
      buttons: [
        {
          text: '详情',
          click: (item: any) => this.msg.success(`配置${item.no}`),
        },
        {
          text: '删除',
          click: (item: any) => this.msg.success(`订阅警报${item.no}`),
        },
      ],
    },
  ];
  selectedRows: STData[] = [];
  description = '';
  totalCallNo = 0;
  expandForm = false;
  baseUrl: string;
  constructor(
    private http: _HttpClient,
    public msg: NzMessageService,
    private modalSrv: NzModalService,
    private cdr: ChangeDetectorRef,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    console.log(this.baseUrl);
    this.getData();
  }

  getData() {
    this.loading = true;
    this.q.statusList = this.status.filter(w => w.checked).map(item => item.index);
    if (this.q.status !== null && this.q.status > -1) {
      this.q.statusList.push(this.q.status);
    }
    this.http
      .get(this.baseUrl + '/api/admin/venue/1', this.q)
      .pipe(
        map((res: any) =>
          res.obj.map(i => {
            return i;
          }),
        ),
        tap(() => (this.loading = false)),
      )
      .subscribe(res => {
        this.data = res;
        this.cdr.detectChanges();
      });
  }

  stChange(e: STChange) {
    switch (e.type) {
      case 'checkbox':
        this.selectedRows = e.checkbox!;
        this.totalCallNo = this.selectedRows.reduce((total, cv) => total + cv.callNo, 0);
        this.cdr.detectChanges();
        break;
      case 'filter':
        this.getData();
        break;
    }
  }

  remove() {
    this.http.delete('/rule', { nos: this.selectedRows.map(i => i.no).join(',') }).subscribe(() => {
      this.getData();
      this.st.clearCheck();
    });
  }

  approval() {
    this.msg.success(`审批了 ${this.selectedRows.length} 笔`);
  }

  reset() {
    // wait form reset updated finished
    setTimeout(() => this.getData());
  }
}
